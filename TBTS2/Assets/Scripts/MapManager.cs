using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    

    public void Start()
    {
        GameObjectFactory gameObjectFactory = GameObject.FindObjectOfType<GameObjectFactory>();
        TileSet tileSet = new TileSet("TileSet", 9, 9, Vector3.zero, gameObjectFactory).Create();
        TileSet tileSet2 = new TileSet("TileSet2", 7, 7, new Vector3(12, 0, 0), gameObjectFactory).Create();

        PrepareBFS();
    }


    void PrepareBFS()
    {
        foreach (TileBFSScript tile in FindObjectsOfType<TileBFSScript>())
        {
            tile.GetComponent<TileBFSScript>().CalculateAdjacency();
        }
    }
}
