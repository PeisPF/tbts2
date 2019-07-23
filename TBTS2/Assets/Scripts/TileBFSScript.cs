using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBFSScript : MonoBehaviour
{
    public bool visited;
    //startin Tile
    public bool active;
    public int stepToReach;
    public LayerMask layerMask;

    public List<TileBFSScript> adjacency = new List<TileBFSScript>();

    public void CalculateAdjacency()
    {

        Vector3[] directions = new Vector3[] { Vector3.forward, Vector3.left, Vector3.right, Vector3.back };
        Vector3 origin = this.transform.position;
        int maxDistance = 1;
        foreach( Vector3 direction in directions )
        {
            RaycastHit raycastHit;
            bool hit = Physics.Raycast(origin, direction, out raycastHit, maxDistance, layerMask);
            if (hit)
            {
                Debug.Log("hit");
                TileBFSScript tileBFSScript = raycastHit.collider.GetComponent<TileBFSScript>();
                adjacency.Add(tileBFSScript);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
