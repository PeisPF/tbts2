using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchableDirectional : Stretchable
{
    public Vector3 stretchDirection;
    

    

    public override void Stretch(int stretchX, int stretchZ)
    {
        GameObject stretchablePart = this.gameObject;
        int stretchAmount;
        int moveAmount;
        if (stretchDirection == Vector3.right)
        {
            stretchAmount = stretchZ;
            moveAmount = stretchX;
        }
        else
        {
            stretchAmount = stretchX;
            moveAmount = stretchZ;
        }
        for (int i = 0; i < stretchAmount; i++)
        {
            GameObject first = gameObjectFactory.Duplicate(stretchablePart).Parent(this.transform.parent.transform).Position(stretchDirection * i+((this.transform.parent.position- this.transform.position)*moveAmount)).Create();
            GameObject second = gameObjectFactory.Duplicate(stretchablePart).Parent(this.transform.parent.transform).Position(stretchDirection * -i+ (this.transform.parent.position - this.transform.position * moveAmount)).Create();
            //first.transform.position *= (moveAmount);
            //second.transform.position *=  (moveAmount);
        }
        Destroy(this.gameObject);
        
        //this.transform.position += moveDirection*(moveAmount);
    }
}
