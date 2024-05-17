using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EffectiveArea : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score=0;
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("“–‚½‚Á‚½");
        //PlaneMaster pm = col.gameObject.GetComponent<PlaneMaster>();
        //score += pm.myScore;
        //pm.myScore = 0;
        text.text = " score :" + score.ToString(); 
    }
}
