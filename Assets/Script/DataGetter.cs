using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using MiniJSON;
using System.IO;
using SimpleJSON;

public class DataGetter : MonoBehaviour
{

    private string url_Arrival = "https://api.odpt.org/api/v4/odpt:FlightInformationArrival?odpt:operator=odpt.Operator:ANA&acl:consumerKey=your_token_code";
    private string url_Departure = "https://api.odpt.org/api/v4/odpt:FlightInformationDeparture?odpt:operator=odpt.Operator:ANA&acl:consumerKey=c7d98943fdb5eb0daff0a1a573b844c1f5602ed2fd588708efce018615c0657b";
    private string url_AirPort = "https://api.odpt.org/api/v4/odpt:Airport?acl:consumerKey=c7d98943fdb5eb0daff0a1a573b844c1f5602ed2fd588708efce018615c0657b";
    public string url_FlightStatus_InAir_ANA = "https://api.odpt.org/api/v4/odpt:FlightInformationDeparture?odpt:operator=odpt.Operator:ANA&odpt:flightStatus=odpt.FlightStatus:InAir&acl:consumerKey=c7d98943fdb5eb0daff0a1a573b844c1f5602ed2fd588708efce018615c0657b";
    public string _textAsset;
    private string _setUpData;
    private string setUpJson;
    public List<Item_inAir> item_inAir = new List<Item_inAir>();

    private void Start()
    {
        StartSetting();
        
        

    }
    public void Gettingdata(string URL)
    {
        StartCoroutine("GetData", URL);
    }
    public string JsonWrapper(string jsonData)
    {
        return setUpJson = "{\"Header\":" + _setUpData + "}";
    }
    private IEnumerator GetData(string URL)
    {
        UnityWebRequest responce = UnityWebRequest.Get(URL);
        yield return responce.SendWebRequest();

        switch (responce.result)
        {
            case UnityWebRequest.Result.InProgress:
                Debug.Log("requesting");
                break;
            case UnityWebRequest.Result.Success:
                _textAsset = responce.downloadHandler.text;
                Debug.Log(_textAsset);
                break;
        }
    }
    public void StartSetting()
    {
        StartCoroutine("GetStart", url_FlightStatus_InAir_ANA);
    }
    private IEnumerator GetStart(string URL)
    {
        UnityWebRequest responce = UnityWebRequest.Get(URL);
        yield return responce.SendWebRequest();

        switch (responce.result)
        {
            case UnityWebRequest.Result.InProgress:
                Debug.Log("requesting");
                break;
            case UnityWebRequest.Result.Success:
                _setUpData = responce.downloadHandler.text;
                break;
        }
        setUpJson = JsonWrapper(_setUpData);
        Debug.Log(setUpJson);
        JsonNode jsonNode = JsonNode.Parse(setUpJson);
        foreach(JsonNode firstAir in jsonNode["Header"]){
            Debug.Log(firstAir["odpt:actualDepartureTime"].Get<string>());
        }
    }
}
