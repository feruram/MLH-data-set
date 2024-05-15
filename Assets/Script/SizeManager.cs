using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    public float worldSize = 1.0f;
    public float size = 1.0f;

    void upDate()
    {
        this.worldSize = size;
    }
}
