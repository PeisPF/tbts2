using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchablePartScript : MonoBehaviour
{

    private Vector3 stretchDirection;
    private GameObjectFactory gameObjectFactory;
    // Start is called before the first frame update

    void Start()
    {
        gameObjectFactory = GameObject.FindObjectOfType<GameObjectFactory>();
    }

    public void Stretch(int stretchAmount)
    {
        GameObject stretchablePart = this.gameObject;
        for (int i = 0; i < stretchAmount; i++)
        {
            gameObjectFactory.Duplicate(stretchablePart).Position(stretchDirection * i).Parent(this.transform.parent.transform).Create();
        }
    }

    public void SetStretchDirection(Vector3 stretchDirection)
    {
        this.stretchDirection = stretchDirection;
    }
}
