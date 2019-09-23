﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GetComponent<FishState>().curr == FishObject.State.Attack)
        {
            if (collision.transform.tag != "LeftFish")
            {
                FollowTarget ft = collision.gameObject.GetComponent<FollowTarget>();
                ft.enabled = false;
                collision.gameObject.GetComponent<FishState>().StartStun();

                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                AddExplosionForce1(rb, 10f, GetComponent<FollowTarget>().velocity * 2f, 10f);

                GetComponent<FishState>().StartIdle();
            }
        }
    }

    private void AddExplosionForce1(Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
    {
        var dir = (body.transform.position - explosionPosition);
        float wearoff = 1 - (dir.magnitude / explosionRadius);
        body.AddForce(dir.normalized * explosionForce * wearoff, ForceMode2D.Impulse);
    }
}