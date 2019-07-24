using System.Collections;
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
        foreach( Vector3 direction in directions )
        {
            Ray ray = new Ray(origin, direction);
            RaycastHit raycastHit;
            bool hit = Physics.Raycast(ray, out raycastHit, maxDistance);
            if (hit)
            {
                Debug.Log("my position is: " + this.transform.position);
                Debug.Log("target position is: " + raycastHit.collider.transform.position);
                Debug.Log("hit collider: " + raycastHit.collider.gameObject.name + " at a distance of " + raycastHit.distance);
                Debug.DrawRay(ray.origin, ray.direction * raycastHit.distance, Color.green, 60f, false);
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
