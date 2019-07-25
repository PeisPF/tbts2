using UnityEngine;
using System.Collections;

public class GameObjectFactory : MonoBehaviour
{
    private Object myObject;
    private string name;
    private Vector3 position = Vector3.zero;
    private Quaternion rotation = Quaternion.identity;
    private Transform parent;

    public GameObjectFactory Resource(string resource)
    {
        this.myObject = Resources.Load(resource);
        return this;
    }

    public GameObjectFactory Name(string name)
    {
        this.name = name;
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
        this.position = new Vector3(x, y, z);
        return this;
    }

    public GameObjectFactory Rotation(Quaternion rotation)
    {
        this.rotation = rotation;
        return this;
    }

    public GameObjectFactory Parent(Transform parent)
    {
        this.parent = parent;
        return this;
    }

    public GameObject Create()
    {
        GameObject item = (UnityEngine.GameObject)Instantiate(myObject, position, rotation, parent);
        item.name = name;
        return item;
    }


}
