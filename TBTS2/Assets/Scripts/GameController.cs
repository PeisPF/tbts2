using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObjectFactory gameObjectFactory = gameObject.AddComponent<GameObjectFactory>();
        new TileSet("TileSet", 9, 9, Vector3.zero, gameObjectFactory).Create();
        new TileSet("TileSet2", 7, 7, new Vector3(12,0,0), gameObjectFactory).Create();
        gameObjectFactory.Resource("Player/Capsule").Position(0, 1.05f, 0).Create();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
