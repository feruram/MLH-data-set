using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject gameObj;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openPanel()
    {
        panel.SetActive(true);
        gameObj.SetActive(false);
    } 
    public void closePanel()
    {
        panel.SetActive(false);
        gameObj.SetActive(true);
    }
    
}
