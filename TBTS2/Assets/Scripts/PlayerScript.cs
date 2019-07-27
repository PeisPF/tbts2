using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int movementPerTurn;

    void Start()
    {
        
    }

    public void HighlightTiles()
    {
        TileBFSScript tileBFSScript = FindActiveTile();
        if(tileBFSScript != null)
        {
            tileBFSScript.HightlightTiles(movementPerTurn);
        }
        else
        {
            Debug.LogError("TileBFSScript not found"); 
        }

    }

    public TileBFSScript FindActiveTile()
    {
        float tileHeight = 10f;

        Vector3 origin = this.gameObject.transform.position;
        float maxDistance = (this.transform.localScale.y) / 2 + tileHeight;

        Ray ray = new Ray(origin, Vector3.down);
        RaycastHit raycastHit;
        bool hit = Physics.Raycast(ray, out raycastHit, maxDistance);
        //TODO remove Debug.DrawRay
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.red, 60f, false);
        if (hit)
        {
            TileBFSScript tileBFSScript = raycastHit.collider.GetComponent<TileBFSScript>();
            return tileBFSScript;
        }
        else
        {
            Debug.Log(string.Format("The raycast from {0} to {1} didn't hit anything", ray.origin, ray.direction * maxDistance));
        }
        return null;
    }

}
