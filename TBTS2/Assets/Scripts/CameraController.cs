using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3(3, 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = this.gameController.GetCurrentPlayer();
        this.transform.position = target.transform.position + new Vector3(3, 3, 3);
        this.transform.LookAt(target.transform);
    }
}
