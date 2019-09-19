using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointer : MonoBehaviour
{
    public float speed = 5f;
    [HideInInspector] public Vector3 move = Vector3.zero;


    void Update()
    {
        transform.position += move * speed * Time.deltaTime;
    }
}
