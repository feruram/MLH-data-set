using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlaneLook : MonoBehaviour
{
    public GameObject planeHinge;
    private GameObject parentObject;
    private PlaneMaster master;
    public Material material1;
    public Material material2;
    void Start()
    {
        TimeSpan blue = new TimeSpan(4, 0, 0);
        TimeSpan purple = new TimeSpan(8, 0, 0);
        parentObject = transform.parent.gameObject;
        master = parentObject.GetComponent<PlaneMaster>();
        if (master.totalTime > blue)
        {
            GameObject body=this.transform.GetChild(0).gameObject;
            body.GetComponent<MeshRenderer>().material = material1;
        }
        else if(master.totalTime>purple)
        {
            GameObject body = this.transform.GetChild(0).gameObject;
            body.GetComponent<MeshRenderer>().material = material2;
        }
    }
    void Update()
    {
        this.transform.position = planeHinge.transform.position;
        var direction = master.destinationPort.transform.position - this.transform.position;
        var look = Quaternion.LookRotation(direction, this.transform.up);
        look.y = 0;
        look.z = 0;
        this.transform.localRotation = look;
    }
}
