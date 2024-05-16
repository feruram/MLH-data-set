using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//takanosuke
public class CameraMove : MonoBehaviour
{
    public GameObject plane;
    private Transform planeTrans;
    void Start()
    {
        planeTrans=plane.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(planeTrans.position);
    }
}
//takanosuke
