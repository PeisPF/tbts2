using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject currentPlayer;
    private TileBFSScript currentSelection;

    void Start()
    {
        GameObjectFactory gameObjectFactory = NewGameObjectFactory();
        NewMapManager().InitializeMap();
        this.currentPlayer = gameObjectFactory.Id("Player").Resource("Player/Player").Position(0, 1.05f, 0).Create();
        currentPlayer.GetComponent<PlayerScript>().HighlightTiles();
    }

    private MapManager NewMapManager()
    {
        return gameObject.AddComponent<MapManager>();
    }

    private GameObjectFactory NewGameObjectFactory()
    {
        return gameObject.AddComponent<GameObjectFactory>();
    }

    public GameObject GetCurrentPlayer()
    {
        return this.currentPlayer;
    }

    void Update()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            TileBFSScript tileBFSScript = objectHit.GetComponent<TileBFSScript>();
            if (tileBFSScript != null)
            {
                if(currentSelection!=null && currentSelection!=tileBFSScript)
                {
                    currentSelection.Deselected();
                }
                currentSelection = tileBFSScript;
                tileBFSScript.Selected();
            }

        }
    }

}
