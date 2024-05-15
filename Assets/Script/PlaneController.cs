using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public FlightinAir myInfo;

    public Vector3 origine;
    public Vector3 destination;
    public float lat;
    public float lon;
    public float progress;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(lat, 0, lon);
    }
}
