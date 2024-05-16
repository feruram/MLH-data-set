using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotate : MonoBehaviour
{
    //takano
    public float speed=1.0f;
    void Update()
    {
        this.transform.Rotate(0, 0,speed * 0.1f);
    }
}
//takano