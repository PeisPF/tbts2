using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBFSScript : MonoBehaviour
{
    public List<TileBFSScript> neighbours = new List<TileBFSScript>();

    public void CalculateNeighbours()
    {
        Vector3[] directions = new Vector3[] { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        Vector3 origin = this.transform.position;
        int maxDistance = 1;
        foreach (Vector3 direction in directions)
        {
            Ray ray = new Ray(origin, direction);
            RaycastHit raycastHit;
            bool hit = Physics.Raycast(ray, out raycastHit, maxDistance);
            if (hit)
            {
                //TODO remove Debug.DrawRay
                Debug.DrawRay(ray.origin, ray.direction * raycastHit.distance, Color.green, 60f, false);
                TileBFSScript tileBFSScript = raycastHit.collider.GetComponent<TileBFSScript>();
                neighbours.Add(tileBFSScript);
            }
        }
    }

    public void HighlightTiles(int remainingMovements)
    {
        Action<TileBFSScript> highlight = delegate (TileBFSScript tileBFSScript)
                                            {
                                                tileBFSScript.GetComponent<Renderer>().material.color = Color.red;
                                            };
        VisitAll(new BFSStatus(), null, remainingMovements, highlight);

    }

    private BFSStatus VisitAll(BFSStatus bFSStatus, TileBFSScript predecessor, int distance, Action<TileBFSScript> action)
    {
        if (distance>0)
        {
            bFSStatus.Visit(this, predecessor, action);
            distance--;
            foreach (TileBFSScript neighbour in this.neighbours)
            {
                bool alreadyVisited = bFSStatus.Contains(neighbour);
                if (!alreadyVisited)
                {
                    neighbour.VisitAll(bFSStatus, this, distance, action);
                }
            }
        }
        return bFSStatus;
    }

    public class BFSNode
    {
        private TileBFSScript current;
        private TileBFSScript predecessor;

        public BFSNode(TileBFSScript current, TileBFSScript predecessor)
        {
            this.current = current;
            this.predecessor = predecessor;
        }

        public TileBFSScript GetCurrent()
        {
            return this.current;
        }

    }

    class BFSStatus
    {   
        private List<BFSNode> visited = new List<BFSNode>();

        public bool Contains(TileBFSScript tileBFSScript)
        {
            return visited.Exists(bfsNode => bfsNode.GetCurrent()==tileBFSScript);
        }

        public void Visit(TileBFSScript tileBFSScript, TileBFSScript predecessor, Action<TileBFSScript> action)
        {
            BFSNode bFSNode = new BFSNode(tileBFSScript, predecessor);
            this.visited.Add(bFSNode);
            action(tileBFSScript);

        }

        public List<TileBFSScript> GetVisited()
        {

            List<TileBFSScript> output = new List<TileBFSScript>();
            foreach(BFSNode node in this.visited)
            {
                output.Add(node.GetCurrent());
            }
            return output;
        }


    }
}


