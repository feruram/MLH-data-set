using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlaneMaster : MonoBehaviour
{
    public AirPort originPort;
    public AirPort destinationPort;
    public FlightinAir myInfo;
    [SerializeField] private string dep;
    [SerializeField] private string arr;
    [SerializeField] public string origin;
    [SerializeField] public string destination;
    public float lat;
    public float lon;
    public float progress;
    public TimeSpan progressTime;
    public TimeSpan totalTime;
    public int myScore;
    // Start is called before the first frame update
    void Start()
    {
        TimeSpan blue = new TimeSpan(4, 0, 0);
        TimeSpan purple = new TimeSpan(8, 0, 0);
        StartCoroutine(DelayCoroutine());
        this.name = myInfo.flightNumber;
        totalTime = myInfo.arrival - myInfo.departure;
        dep = myInfo.departure.ToString();
        arr = myInfo.arrival.ToString();
        origin = myInfo.originPort;
        destination = myInfo.destinationPort;
        myScore = 100;
        if (totalTime > blue)
        {
            myScore = 400;
        }
        else if (totalTime > purple)
        {
            myScore = 800;
        }
    }
    void Update()
    {

        if (progress > 1.0f)
        {
            Destroy(this.gameObject);
        }
    }
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(3);
    }
}
