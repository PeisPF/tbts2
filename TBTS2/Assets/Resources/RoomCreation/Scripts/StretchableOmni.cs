﻿using System.Collections;
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
                //TODO da fixare
                //gameObjectFactory.Duplicate(this.gameObject).Parent(this.transform.parent).Position(this.transform.parent.position + new Vector3(x, 0, z)).Create();
            }
        }
        Destroy(this.gameObject);
    }
}
