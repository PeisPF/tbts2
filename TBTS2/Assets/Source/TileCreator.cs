using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Object tileObject = Resources.Load("Tiles/Tile");
        GameObject tile = (UnityEngine.GameObject) Instantiate(tileObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
