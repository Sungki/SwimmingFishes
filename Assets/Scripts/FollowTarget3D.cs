using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget3D : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;
    Vector3 velocity;

    void Update()
    {
        transform.LookAt(target.transform.position);
        velocity = target.transform.position - transform.position;
        transform.position = transform.position + velocity * Time.deltaTime * speed;
    }
}
