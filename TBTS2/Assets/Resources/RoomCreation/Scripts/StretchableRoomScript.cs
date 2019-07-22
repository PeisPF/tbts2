using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchableRoomScript : MonoBehaviour
{

    
   

    // Start is called before the first frame update
    void Start()
    {
        Stretchable stretchable = this.gameObject.GetComponent<Stretchable>();
        stretchable.stretchablePart.Stretch(4);
        stretchable.endOfStretchablePartScript.Stretch(4);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
