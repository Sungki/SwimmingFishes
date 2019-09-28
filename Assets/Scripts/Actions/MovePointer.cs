﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointer : MonoBehaviour
{
    public float speed = 5f;
    [HideInInspector] public Vector3 move = Vector3.zero;


    void Update()
    {
        transform.position += move * speed * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -12, 12);
        pos.y = Mathf.Clamp(pos.y, -6, 6);


        transform.position = pos;
    }
}
