using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPortReader : MonoBehaviour
{
    public gameObject portPrefab;
    public List<string[]> csvDatas = new List<string[]>();
    public float radius = 10f;
    void start()
    {
        StringReader reader = new StringReader(Resources.Load("airports.csv").text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
        }
        Debug.Log("finished loading");
        for(int i=0;i<800;i++){
            string _port = csvDatas[i][0];
            float _lat = csvDatas[i][1];
            float _lon = csvDatas[i][2];
            Instantiate(portPrefab, new Vector3(radius, 0, 0), Quaternion.identify);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
