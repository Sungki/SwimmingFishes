using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    private GameObject myCanvas;
    public Text[] textArray;

    private void Awake()
    {
        myCanvas = GameObject.Find("Canvas");
        if(myCanvas) textArray = myCanvas.GetComponentsInChildren<Text>();
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