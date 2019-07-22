using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonStretchable : Stretchable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Stretch(int stretchX, int stretchZ)
    {
        this.transform.position = new Vector3(this.transform.position.x*stretchZ, 0, this.transform.position.z * stretchX);
    }

}
