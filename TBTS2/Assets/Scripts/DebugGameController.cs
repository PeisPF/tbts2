using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGameController : GameController
{

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Object myObject = Resources.Load("Tiles/Tile");
        CreateTile(myObject, 0, 0);
        CreateTile(myObject, 1, 0);
        CreateTile(myObject, 1, 1);
        CreateTile(myObject, 0, 1);
        CreateTile(myObject, 3, 0);
        CreateTile(myObject, 4, 0);


        PrepareBFS(FindObjectsOfType<TileBFSScript>());
    }

    void PrepareBFS(TileBFSScript[] tiles)
    {
        foreach (TileBFSScript tile in tiles)
        {
            tile.GetComponent<TileBFSScript>().CalculateAdjacency();
        }
    }

    private GameObject CreateTile(Object myObject, int x, int z)
    {
        GameObject instantiated =(UnityEngine.GameObject)Instantiate(myObject, new Vector3(x,0,z), Quaternion.identity);
        return instantiated;
    }
}
