using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileSet
{
    private Vector3 center;
    private int sizeX;
    private int sizeZ;
    private string name;
    private GameObjectFactory gameObjectFactory;

    public TileSet(string name, int sizeX, int sizeZ, Vector3 center, GameObjectFactory gameObjectFactory)
    {
        this.name = name;
        this.sizeX = sizeX;
        this.sizeZ = sizeZ;
        this.center = center;
        this.gameObjectFactory = gameObjectFactory;
    }

    // Start is called before the first frame update
    public TileSet Create()
    {
        GameObject tileSet = new GameObject(this.name);

        int startX = (int)center.x - Mathf.FloorToInt(sizeX / 2);
        int endX = startX + sizeX;
        int startZ = (int)center.z - Mathf.FloorToInt(sizeZ / 2);
        int endZ = startZ + sizeZ;
        for (int x=startX; x < endX; x++){
            for (int z=startZ; z < endZ; z++){
                gameObjectFactory.Resource("Tiles/Tile").Parent(tileSet.transform).Position(x,z).Create();
            }
        }
        return this;
        
    }




}
