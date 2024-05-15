using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    SizeManager sm;
    void Start()
    {
        GameObject manager = GameObject.Find("SizeManager");
        sm = manager.GetComponent<SizeManager>();
    }
    void Update()
    {
        this.transform.localScale = new Vector3(sm.worldSize, sm.worldSize, sm.worldSize);
    }
}
