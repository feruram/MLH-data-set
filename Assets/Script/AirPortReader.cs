using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Text;

public class AirPortReader : MonoBehaviour
{
    public GameObject portPrefab;
    public GameObject hanedaPortPrefab;
    private TextAsset csvFile;
    public List<string[]> csvDatas = new List<string[]>();
    public List<string[]> csvDatas2 = new List<string[]>();
    public float radius = 10f;
    public float haneda_lat = 35.5523f;
    public float haneda_lon=139.78f;
    public string haneda_name = "HND";
    void Start()
    {
        Debug.Log("1");
        csvFile = Resources.Load("AirPortANA") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
            Debug.Log("1");
        }
        Debug.Log("finished loading");
        /*
        for(int i=0;i<800;i++){
            string _port = csvDatas[i][0];
            float _lat = float.Parse(csvDatas[i][1]);
            float _lon = float.Parse(csvDatas[i][2]);
            Vector3 point = new Vector3(radius, 0, 0);
            point = Quaternion.Euler(0, _lat, _lon) * point;
            var portObj=Instantiate(portPrefab, point, Quaternion.identity);
            portObj.name = _port;
            
        }
        */
        Vector3 hanedaPoint = new Vector3(radius, 0, 0);
        hanedaPoint = Quaternion.Euler(0, haneda_lat, haneda_lon) * hanedaPoint;
        var hanedaObj = Instantiate(hanedaPortPrefab, hanedaPoint, Quaternion.identity);
        hanedaObj.name = haneda_name;
    }

}
