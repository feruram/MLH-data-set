using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class InputManager : MonoBehaviour
{
    //takano
    public static int tmz;
    [SerializeField] TMP_InputField inputField;
    void Start()
    {
    }

    public void GetInputName()
    {
        string data=inputField.text;
        tmz = int.Parse(data);  
        Debug.Log(tmz);
    }
    public void startButton()
    {
        SceneManager.LoadScene("flight-catcher");
    }
}
