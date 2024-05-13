using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataGetter : MonoBehaviour
{
    private string url_Arrival = "https://api.odpt.org/api/v4/odpt:FlightInformationArrival?odpt:operator=odpt.Operator:ANA&acl:consumerKey=c7d98943fdb5eb0daff0a1a573b844c1f5602ed2fd588708efce018615c0657b";
    private string url_Departure = "https://api.odpt.org/api/v4/odpt:FlightInformationDeparture?odpt:operator=odpt.Operator:ANA&acl:consumerKey=c7d98943fdb5eb0daff0a1a573b844c1f5602ed2fd588708efce018615c0657b";

    private void Start()
    {
        Gettingdata();
    }
    public void Gettingdata()
    {
        StartCoroutine("GetData", url_Arrival);
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
                Debug.Log(responce.downloadHandler.text);
                break;
        }
    }
}
