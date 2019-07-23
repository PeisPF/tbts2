using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject currentPlayer;

    void Start()
    {
        GameObjectFactory gameObjectFactory = gameObject.AddComponent<GameObjectFactory>();
        TileSet tileSet = new TileSet("TileSet", 9, 9, Vector3.zero, gameObjectFactory).Create();
        TileSet tileSet2 = new TileSet("TileSet2", 7, 7, new Vector3(12, 0, 0), gameObjectFactory).Create();
        this.currentPlayer = gameObjectFactory.Resource("Player/Player").Position(0, 1.05f, 0).Create();
        PrepareBFS(tileSet.GetTiles());
        PrepareBFS(tileSet2.GetTiles());

    }

    public GameObject GetCurrentPlayer()
    {
        return this.currentPlayer;
    }

    void Update()
    {
        
    }

    void PrepareBFS(List<GameObject> tiles)
    {
        foreach(GameObject tile in tiles)
        {
            tile.GetComponent<TileBFSScript>().CalculateAdjacency();
        }
    }
}
