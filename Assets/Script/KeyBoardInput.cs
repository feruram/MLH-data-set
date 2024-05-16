using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardInput : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    public float X_rot;
    public float Y_rot;
    public float speed = 20.0f;
    public bool isFPS=true;
    SizeManager sm;
    private GameObject effectObj;
    private float one_sec;
    private float effectTime;
    void Start()
    {
        GameObject manager = GameObject.Find("SizeManager");
        sm = manager.GetComponent<SizeManager>();
        Vector3 startPoint = new Vector3(20.2f*sm.worldSize, 0, 0);
        startPoint = Quaternion.Euler(0, -139.78f, 35.5523f) * startPoint;
        player.transform.position = startPoint;
        effectObj = player.transform.GetChild(0).gameObject;
        one_sec = 1.0f;
        effectTime = 3.0f;
        effectObj.SetActive(false);
    }
    void Update()
    {
        X_rot = Input.GetAxis("Mouse X");
        Y_rot = Input.GetAxis("Mouse Y");
        player.transform.Rotate(-Y_rot, X_rot, 0);
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += player.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position -= player.transform.forward * speed * Time.deltaTime;
        }
        one_sec += Time.deltaTime;
        effectTime += Time.deltaTime;
        if (one_sec >= 1.0f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (isFPS)
                {
                    isFPS = false;
                }
                else
                {
                    isFPS = true;
                }
                one_sec = 0f;
            }
        }
        if (isFPS)
        {
            camera.transform.position = player.transform.position;
            camera.transform.rotation = player.transform.rotation;
        }
        if (effectTime >= 2.0)
        {
            effectObj.SetActive(false);
            if (effectTime >= 3.0f)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    effectObj.SetActive(true);
                    effectTime = 0f;
                }

            }
        }
    }
}
