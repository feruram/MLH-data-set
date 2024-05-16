using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EffectiveArea : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int score=0;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("“–‚½‚Á‚½");
        PlaneMaster pm = collision.gameObject.GetComponent<PlaneMaster>();
        score += pm.myScore;
        text.text = " score :" + score.ToString(); 
    }
}
