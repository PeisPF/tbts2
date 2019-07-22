using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchableOmni : Stretchable
{
    public override void Stretch(int stretchX, int stretchZ)
    {
        for (int x =-stretchZ+1; x < stretchZ; x++)
        {
            for (int z=-stretchX+1;z<stretchX; z++)
            {
                gameObjectFactory.Duplicate(this.gameObject).Position(x, 0, z).Parent(this.transform.parent).Create();
            }
        }
        Destroy(this.gameObject);
    }
}
