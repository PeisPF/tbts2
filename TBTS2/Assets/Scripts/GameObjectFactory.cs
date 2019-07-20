using UnityEngine;
using System.Collections;

public class GameObjectFactory : MonoBehaviour
{
    public GameObject Create(Transform parent, string resource, float x, float z)
    {
        return Create(parent, resource, x, 0, z); 
    }

    public GameObject Create(Transform parent, string resource, float x, float y, float z)
    {
        UnityEngine.Object tileObject = Resources.Load(resource);
        GameObject myGameObject = (UnityEngine.GameObject)Instantiate(tileObject);
        myGameObject.transform.SetParent(parent);
        Vector3 position = new Vector3(x, 0, z);
        myGameObject.transform.position = position;
        return myGameObject;
    }
}
