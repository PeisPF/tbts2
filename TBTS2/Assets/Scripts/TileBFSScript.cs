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

        BFSStatus bFSStatus = VisitAll(new BFSStatus(), remainingMovements);
        foreach(TileBFSScript visited in bFSStatus.GetVisited())
        {
            visited.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private BFSStatus VisitAll(BFSStatus bFSStatus, int distance)
    {
        if (distance>0)
        {
            bFSStatus.Visit(this);
            distance--;
            foreach (TileBFSScript neighbour in this.neighbours)
            {
                bool alreadyVisited = bFSStatus.Contains(neighbour);
                if (!alreadyVisited)
                {
                    neighbour.VisitAll(bFSStatus, distance);
                }
            }
        }
        return bFSStatus;
    }

    class BFSStatus
    {   
        private List<TileBFSScript> visited = new List<TileBFSScript>();

        public bool Contains(TileBFSScript gameObject)
        {
            return visited.Contains(gameObject);
        }

        public void Visit(TileBFSScript gameObject)
        {
            this.visited.Add(gameObject);
        }

        public List<TileBFSScript> GetVisited()
        {
            return visited;
        }


    }
}


