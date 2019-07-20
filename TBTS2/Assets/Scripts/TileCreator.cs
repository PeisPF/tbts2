using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject tileSet = new GameObject("TileSet");
        UnityEngine.Object tileObject = Resources.Load("Tiles/Tile");
        for (int x = -4; x < 5; x++){
            for (int z = -4; z < 5; z++){
                GameObject tile = (UnityEngine.GameObject)Instantiate(tileObject);
                tile.transform.SetParent(tileSet.transform);
                Vector3 position = new Vector3(x,0,z);
                tile.transform.position = position;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
