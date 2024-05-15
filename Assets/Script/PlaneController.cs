using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlaneController : MonoBehaviour
{
    public FlightinAir myInfo;
    [SerializeField]private string dep;
    [SerializeField] private string arr;
    [SerializeField] private string origin;
    [SerializeField] private string destination;
    public float lat;
    public float lon;
    public float progress;
    public TimeSpan progressTime;
    private TimeSpan totalTime;
    public AirPort originPort;
    public AirPort destinationPort;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayCoroutine());
        this.name = myInfo.flightNumber;
        totalTime = myInfo.arrival - myInfo.departure;
        dep = myInfo.departure.ToString();
        arr = myInfo.arrival.ToString();
        origin = myInfo.originPort;
        destination = myInfo.destinationPort;
    }
    // Update is called once per frame
    void Update()
    {
        progressTime = DateTime.Now - myInfo.departure;
        progress = (float)progressTime.TotalSeconds / (float)totalTime.TotalSeconds;
        lat = originPort.lat + (destinationPort.lat - originPort.lat) * progress;
        lon = originPort.lon + (destinationPort.lon - originPort.lat) * progress;
        this.transform.rotation = Quaternion.Euler(0, lat, lon);
    }
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(3);
    }
}
