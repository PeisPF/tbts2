using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfStretchablePartScript : MonoBehaviour
{
    private Vector3 stretchDirection;

    public void SetStretchDirection(Vector3 stretchDirection)
    {
        this.stretchDirection = stretchDirection;
    }
    // Start is called before the first frame update
    public void Stretch(int stretchAmount)
    {
        GameObject endOfStretchablePart = this.gameObject;
        endOfStretchablePart.transform.position += stretchDirection * (stretchAmount - 1);
    }
}
