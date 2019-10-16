using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    void Start()
    {
        Toolbox.GetInstance().GetManager<GameManager>().Init();
    }
}
