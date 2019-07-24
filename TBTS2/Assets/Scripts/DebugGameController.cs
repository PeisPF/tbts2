using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGameController : GameController
{
    // Start is called before the first frame update
    void Start()
    {
        PrepareBFS(FindObjectsOfType<TileBFSScript>());
    }

    void PrepareBFS(TileBFSScript[] tiles)
    {
        foreach (TileBFSScript tile in tiles)
        {
            tile.GetComponent<TileBFSScript>().CalculateAdjacency();
        }
    }
}
