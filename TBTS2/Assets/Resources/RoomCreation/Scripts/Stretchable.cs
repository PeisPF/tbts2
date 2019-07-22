using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stretchable : MonoBehaviour
{
    public abstract void Stretch(int stretchX, int stretchZ);
    protected GameObjectFactory gameObjectFactory;
    void Start()
    {
        gameObjectFactory = GameObject.FindObjectOfType<GameObjectFactory>();
    }

}
