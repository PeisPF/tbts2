﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBFSScript : MonoBehaviour
{
    public bool visited;
    //startin Tile
    public bool active;
    public int stepToReach;

    public List<TileBFSScript> adjacency = new List<TileBFSScript>();

    public void CalculateAdjacency()
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
                adjacency.Add(tileBFSScript);
            }
        }
    }

    public void HighlightTiles(int remainingMovements)
    {

        BFSStatus bFSStatus = HighlightTiles(new BFSStatus(remainingMovements));
        foreach(TileBFSScript visited in bFSStatus.GetVisited())
        {
            visited.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private BFSStatus HighlightTiles(BFSStatus bFSStatus){
        bFSStatus.Visit(this.gameObject);
        if (bFSStatus.HasRemainingMovements())
        {
            bFSStatus.Moved();
            foreach (TileBFSScript tileBFSScript in adjacency)
            {
                if (!bFSStatus.Contains(tileBFSScript))
                {
                    tileBFSScript.HighlightTiles(bFSStatus);
                }
            }
        }
        return bFSStatus;
    }

    class BFSStatus
    {   
        private List<TileBFSScript> visited;
        private int remainingMovements;

        public BFSStatus(int remainingMovements)
        {
            this.remainingMovements = remainingMovements;
        }

        public bool HasRemainingMovements()
        {
            return remainingMovements > 0;
        }

        public void Moved()
        {
            remainingMovements--;
        }

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


