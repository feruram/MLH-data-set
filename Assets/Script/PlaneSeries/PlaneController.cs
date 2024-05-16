using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlaneController : MonoBehaviour
{
    public bool qualified = false;
    private GameObject parentObject;
    private PlaneMaster master;
    void Start()
    {

        parentObject = transform.parent.gameObject;
        master = parentObject.GetComponent<PlaneMaster>();
        qualified = true;
    }
    // Update is called once per frame
    void Update()
    {
        master.progressTime = DateTime.Now - master.myInfo.departure;
        master.progress = (float)master.progressTime.TotalSeconds / (float)master.totalTime.TotalSeconds;
        master.lat = master.originPort.lat + (master.destinationPort.lat - master.originPort.lat) * master.progress;
        master.lon = master.originPort.lon + (master.destinationPort.lon - master.originPort.lon) * master.progress;
        this.transform.rotation = Quaternion.Euler(0, master.lat, master.lon);

        if (master.progress > 1.0f)
        {
            Destroy(this.gameObject);
        }
    }
   
}
