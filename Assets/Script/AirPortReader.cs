using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Text;
using System;

public class AirPortReader : MonoBehaviour
{
    public GameObject portPrefab;
    public GameObject hanedaPortPrefab;
    public GameObject parentObject;
    private TextAsset csvFile;
    public List<string[]> portDatas = new List<string[]>();
    public float radius = 10f;
    public float haneda_lat = 35.5523f;
    public float haneda_lon=139.78f;
    public string haneda_name = "HND";
    void Start()
    {
        csvFile = Resources.Load("AirPortDatas") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            portDatas.Add(line.Split(','));
            Debug.Log("1");
        }
        Debug.Log("finished loading");
        Debug.Log(portDatas.Count);
        for (int i = 0; i < portDatas.Count; i++)
        {
            string _port = portDatas[i][0];
            float _lat = float.Parse(portDatas[i][1]);
            float _lon = float.Parse(portDatas[i][2]);
            Vector3 point = new Vector3(radius, 0, 0);
            point = Quaternion.Euler(0, _lat, _lon) * point;
            var portObj = Instantiate(portPrefab, point, Quaternion.identity);
            portObj.name = _port;
            portObj.transform.SetParent(parentObject.transform, true);
        }
        Debug.Log("plot finished");
        Vector3 hanedaPoint = new Vector3(radius, 0, 0);
        hanedaPoint = Quaternion.Euler(0, haneda_lat, haneda_lon) * hanedaPoint;
        var hanedaObj = Instantiate(hanedaPortPrefab, hanedaPoint, Quaternion.identity);
        hanedaObj.name = haneda_name;
    }

}
