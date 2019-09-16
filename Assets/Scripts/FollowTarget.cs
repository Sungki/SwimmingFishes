using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;
    Vector3 velocity;

    void Update()
    {
        Vector3 targetPos = target.transform.position;
        float angleRad = Mathf.Atan2(targetPos.y - this.transform.position.y, targetPos.x - this.transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, angleDeg);

        velocity = targetPos - transform.position;
        velocity.z = transform.position.z;
        transform.position = transform.position + velocity * Time.deltaTime * speed;
    }
}
