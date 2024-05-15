using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using MiniJSON;
using System.IO;
using SimpleJSON;
using System;
using LitJson;

public class DataGetter : MonoBehaviour
{
    private string url_Arrival = "https://api.odpt.org/api/v4/odpt:FlightInformationArrival?";
    private string url_Departure = "https://api.odpt.org/api/v4/odpt:FlightInformationDeparture?";
    private string url_operator_ANA = "odpt:operator=odpt.Operator:ANA&";
    private string operator_JAL = "odpt:operator=odpt.Operator:JAL&";
    private string url_FlightStatus_InAir = "odpt:flightStatus=odpt.FlightStatus:InAir&";
    public bool isStarted = false;
    public bool isRunning = false;
    private string url_comsumerKey = "&acl:consumerKey=";
    public string yourComsumerKey = "c7d98943fdb5eb0daff0a1a573b844c1f5602ed2fd588708efce018615c0657b";
    public List<FlightinAir> inAir_list = new List<FlightinAir>();
    public float GettingSec = 10;
    public FlightSimulator fs;

    private void Start()
    {
        Gettingdata(url_Departure + url_operator_ANA + url_FlightStatus_InAir + url_comsumerKey + yourComsumerKey);
        isStarted = true;
    }
    private void Update()
    {
        if (isStarted&&!isRunning)
        {
            StartCoroutine("Repeat");
            isRunning = true;
        }
    }

    public void Gettingdata(string URL)
    {
        StartCoroutine("GetData", URL);
    }

    public string JsonWrapper(string jsonData)
    {
        string setUpJson;
        return setUpJson = "{\"Header\":" + jsonData + "}";
    }
    private IEnumerator Repeat()
    {
        while (true)
        {
            yield return new WaitForSeconds(GettingSec);
            string nowTime = DateTime.Now.ToString("HH:mm");
            Gettingdata(url_Departure + url_operator_ANA + "odpt:estimatedDepartureTime=" + nowTime + url_comsumerKey + yourComsumerKey);
            
        }
    }
    private IEnumerator GetData(string URL)
    {
        UnityWebRequest responce = UnityWebRequest.Get(URL);
        yield return responce.SendWebRequest();
        string _setUpData="";
        switch (responce.result)
        {
            case UnityWebRequest.Result.InProgress:
                Debug.Log("requesting");
                break;
            case UnityWebRequest.Result.Success:
                _setUpData = responce.downloadHandler.text;
                Debug.Log("StartingUp");
                break;
        }
        string setUpJson = JsonWrapper(_setUpData);
        Debug.Log(setUpJson);
        JsonData jsonData = JsonMapper.ToObject(setUpJson);

        foreach (JsonData oneData in jsonData["Header"])
        {
            string flightNum = (string)oneData["odpt:flightNumber"][0];
            string url_search = url_Arrival + url_operator_ANA + "odpt:flightNumber=" + flightNum + url_comsumerKey + yourComsumerKey;
            UnityWebRequest responce2 = UnityWebRequest.Get(url_search);
            yield return responce2.SendWebRequest();
            string _setUpData2 = "";
            switch (responce2.result)
            {
                case UnityWebRequest.Result.InProgress:
                    Debug.Log("requesting");
                    break;
                case UnityWebRequest.Result.Success:
                    _setUpData2 = responce2.downloadHandler.text;
                    Debug.Log("FlightNumberLoaded");
                    break;
            }
            string setUpJson2 = JsonWrapper(_setUpData2);
            JsonData jsontemp = JsonMapper.ToObject(setUpJson2);
            DateTime _arrivalTime = DateTime.Parse((string)jsontemp["Header"][0]["odpt:estimatedArrivalTime"]);
            FlightinAir tempData = new FlightinAir();
            DateTime _departuredTime = DateTime.Parse((string)oneData["odpt:actualDepartureTime"]);
            if (DateTime.Now < _departuredTime)
                _departuredTime.AddDays(-1);

            if (_departuredTime > _arrivalTime)
                _arrivalTime = _arrivalTime.AddDays(1);

            tempData.departure = _departuredTime;
            tempData.arrival = _arrivalTime;
            string origine = (string)oneData["odpt:departureAirport"];
            tempData.originPort = origine.Replace("odpt.Airport:", "");
            string destination = (string)oneData["odpt:destinationAirport"];
            tempData.destinationPort = destination.Replace("odpt.Airport:", "");
            tempData.flightNumber = flightNum;
            inAir_list.Add(tempData);
            fs.planeCreate(tempData);
        }
    }
    public void Show()
    {
        for(int i = 0; i < inAir_list.Count; i++) {
            Debug.Log(inAir_list[i].departure);
            Debug.Log(inAir_list[i].arrival);
        }
        
    }
}

