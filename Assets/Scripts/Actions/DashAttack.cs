using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    public GameObject[] fish;
    FollowTarget[] ft;
//    MovePointer mv;
    SelectControl sc;
    FishState[] fs;
//    Rigidbody2D[] rb;

    void Start()
    {
//        mv = GetComponent<MovePointer>();
        sc = GetComponent<SelectControl>();

        ft = new FollowTarget[5];
        fs = new FishState[5];
        //        rb = new Rigidbody2D[5];
        for (int i = 0; i < 5; i++)
        {
//            rb[i] = fish[i].GetComponent<Rigidbody2D>();
            ft[i] = fish[i].GetComponent<FollowTarget>();
            fs[i] = fish[i].GetComponent<FishState>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            sc.dash = 20f;
            /*            for (int i = 0; i < 5; i++)
                        {
                            rb[i].AddForce(ft[i].velocity*500f);
                        }*/

            foreach (FollowTarget f in ft)
            {
                f.speed = 10f;
            }

            foreach (FishState f in fs)
            {
                f.curr = FishObject.State.Attack;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (Vector2.Distance(this.transform.position, fish[i].transform.position) < 0.3f)
            {
                  ft[i].speed = 5f;
//                rb[i].AddForce(Vector2.zero);
            }
        }
    }
}
