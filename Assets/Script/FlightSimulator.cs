using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlightSimulator : MonoBehaviour
{
    public DataGetter dg;
    public AirPortReader apr;
    public GameObject planePrefab;
    // Update is called once per frame
    private AirPort originPort;
    private AirPort destinationPort;
    public void planeCreate(FlightinAir inAir)
    {
        foreach(AirPort port in apr.ports)
        {
            if (port.name == inAir.originPort)
                originPort = port;
            if (port.name == inAir.destinationPort)
                destinationPort = port;
        }
        Vector3 planePos = new Vector3(0, 0, 0);
        PlaneController myPlane = Instantiate(planePrefab, planePos, Quaternion.Euler(0, originPort.lat, originPort.lon)).GetComponent<PlaneController>();
        myPlane.originPort = originPort;
        myPlane.destinationPort = destinationPort;
        myPlane.myInfo = inAir;
    }
}
