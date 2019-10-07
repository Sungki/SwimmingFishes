using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    private GameObject myCanvas;
    private Text[] textArray;

    void Start()
    {
        myCanvas = GameObject.Find("Canvas");
        textArray = myCanvas.GetComponentsInChildren<Text>();
    }

    public void ShowHUD(string _str)
    {
        textArray[0].text = _str;
    }

    public void ShowSummary()
    {
    }

    public void InitText()
    {
        textArray[0].text = null;
        textArray[1].text = null;
        textArray[2].text = null;
    }
}