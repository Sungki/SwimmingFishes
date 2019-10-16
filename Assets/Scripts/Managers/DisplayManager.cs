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
        textArray = myCanvas.GetComponentsInChildren<Text>();
    }

//    public static void ShowHUDLeft(string _str)
//    {
//        textArray[0].text = _str;
//    }

//    public static void ShowHUDRight(string _str)
//    {
//        textArray[2].text = _str;
//    }

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