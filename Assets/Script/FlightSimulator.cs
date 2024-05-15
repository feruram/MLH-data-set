using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlightSimulator : MonoBehaviour
{
    public DataGetter dg;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dg.isStarted&&!dg.isRunning)
        {
            dg.Show();
        }
    }
}
