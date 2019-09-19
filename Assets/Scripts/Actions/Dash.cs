using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject[] fish;
    FollowTarget[] ft;
    MovePointer mv;
    SelectControl sc;

    void Start()
    {
        mv = GetComponent<MovePointer>();
        sc = GetComponent<SelectControl>();

        ft = new FollowTarget[5];
        for(int i =0; i<5; i++)
        {
            ft[i] = fish[i].GetComponent<FollowTarget>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sc.dash = 20f;
            foreach (FollowTarget f in ft)
                f.speed = 10f;
        }

        for (int i = 0; i < 5; i++)
        {
            if (Vector2.Distance(this.transform.position, fish[i].transform.position) < 0.2f)
            {
                ft[i].speed = 5f;
            }
        }
    }
}
