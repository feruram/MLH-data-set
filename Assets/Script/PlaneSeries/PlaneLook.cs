using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneLook : MonoBehaviour
{
    public GameObject planeHinge;
    private GameObject parentObject;
    private PlaneMaster master;
    void Start()
    {
        parentObject = transform.parent.gameObject;
        master = parentObject.GetComponent<PlaneMaster>();
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
