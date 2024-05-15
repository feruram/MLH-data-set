using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    void Update()
    {
        this.transform.localScale = new Vector3(SizeManager.worldSize, SizeManager.worldSize, SizeManager.worldSize);
    }
}
