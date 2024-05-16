using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System;
using UnityEngine;
using FromUTCestimateoffset;
using System.Reflection;
public class Calculatetime : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

        String h = @"hh";
        String m = @"mm";
        String s = @"ss";
        String t = @"tt";

        Debug.Log(DateTime.UtcNow);
        Debug.Log(DateTime.Now);
        h = DateTime.UtcNow.ToString(h);
        m = DateTime.UtcNow.ToString(m);
        s = DateTime.UtcNow.ToString(s);
        t = DateTime.UtcNow.ToString(t);
        Debug.Log(h + m + s + t);
        Debug.Log(DateTime.UtcNow.Kind);
        Debug.Log(DateTime.Now.Kind);


        TimeSpan offset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
        Debug.Log(offset.Hours+offset.Minutes+offset.Seconds);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
