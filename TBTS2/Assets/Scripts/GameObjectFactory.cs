using UnityEngine;
using System.Collections;

public class GameObjectFactory : MonoBehaviour
{
    private GameObject myGameObject;

    public GameObjectFactory Duplicate(Object myObject)
    {
        this.myGameObject = (UnityEngine.GameObject)Instantiate(myObject);
        return this;
    }

    public GameObjectFactory Resource(string resource)
    {
        
        UnityEngine.Object myObject = Resources.Load(resource);
        this.myGameObject = (UnityEngine.GameObject)Instantiate(myObject);
        return this;
    }

    public GameObjectFactory Name(string name)
    {
        this.myGameObject.name = name;
        return this;
    }

    public GameObjectFactory Position(float x, float z)
    {
        return Position(x, 0, z);
    }

    public GameObjectFactory Position(Vector3 position)
    {
        return Position(position.x, position.y, position.z);
    }

    public GameObjectFactory Position(float x, float y, float z)
    {
        Vector3 position = new Vector3(x, y, z);
        myGameObject.transform.position = position;
        return this;
    }

    public GameObjectFactory Parent(Transform parent)
    {
        this.myGameObject.transform.SetParent(parent);
        return this;
    }

    public GameObject Create()
    {
        return myGameObject;
    }


}
