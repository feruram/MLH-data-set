using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Getobject : MonoBehaviour
{
    public static List<string> Progress_airport = new List<string>();
    GameObject gameobj;
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        gameobj = collider.gameObject;
        Debug.Log("���̃I�u�W�F�N�g�F" + this.gameObject.name);
        Debug.Log("�Փ˂��ꂽ�I�u�W�F�N�g�F" + gameobj.name);
        Progress_airport.Add(gameobj.name);
        Debug.Log(Progress_airport.Count);
    }
}
