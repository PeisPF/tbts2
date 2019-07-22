using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchableRoomScript : MonoBehaviour
{

    public Vector3 stretchDirection;
    private GameObjectFactory gameObjectFactory;

    // Start is called before the first frame update
    void Start()
    {
        int stretchAmount = 4;
        GameObject stretchablePart = FindStretchablePart();
        for (int i = 0; i < stretchAmount; i++)
        {
            gameObjectFactory.Duplicate(stretchablePart).Position(stretchDirection * i).Parent(this.transform).Create();
        }
        GameObject endOfStretchablePart = FindEndOfStretchablePart();
        endOfStretchablePart.transform.position += stretchDirection * (stretchAmount-1);

    }

    GameObject FindEndOfStretchablePart()
    {
        return FindChildWithTag("EndOfStretchablePart");
    }

    GameObject FindStretchablePart()
    {
        return FindChildWithTag("StretchablePart");
    }

    GameObject FindChildWithTag(string tag)
    {
        gameObjectFactory = GameObject.FindObjectOfType<GameObjectFactory>();
        GameObject[] repeatables = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject repeatable in repeatables)
        {
            if (repeatable.transform.parent == this.transform)
            {
                return repeatable;
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
