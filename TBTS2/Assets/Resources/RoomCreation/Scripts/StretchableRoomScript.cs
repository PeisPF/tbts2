using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchableRoomScript : MonoBehaviour
{

    public int stretchX;
    public int stretchZ;
   

    // Start is called before the first frame update
    void Start()
    {
        Stretchable[] strechables = this.gameObject.GetComponentsInChildren<Stretchable>();
        foreach (Stretchable strechable in strechables)
        {
            strechable.Stretch(stretchX, stretchZ);
        }
        /*NonStretchable[] nonStretchables = this.gameObject.GetComponentsInChildren<NonStretchable>();
        foreach (NonStretchable nonStrechable in nonStretchables)
        {
            nonStrechable.Stretch(stretchX, stretchZ);
        }*/

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
