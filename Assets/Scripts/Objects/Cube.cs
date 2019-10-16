using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("AddScore", 1f, 1f);
    }

    void AddScore()
    {
        Toolbox.GetInstance().GetManager<GameManager>().AddScoreLeft();
        GetComponent<ReduceHP>().Hit();
    }
}
