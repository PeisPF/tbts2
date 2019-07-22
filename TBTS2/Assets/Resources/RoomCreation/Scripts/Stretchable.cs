using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretchable : MonoBehaviour
{
    public Vector3 stretchDirection;
    public StretchablePartScript stretchablePart;
    public EndOfStretchablePartScript endOfStretchablePartScript;

    private void Start()
    {
        endOfStretchablePartScript.SetStretchDirection(this.stretchDirection);
        stretchablePart.SetStretchDirection(this.stretchDirection);
    }
}
