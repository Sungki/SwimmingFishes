using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;
    [HideInInspector] public Vector3 velocity;

    public bool isCollision = false;

/*    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }*/

    void Update()
    {
        Vector3 targetPos = target.transform.position;
        float angleRad = Mathf.Atan2(targetPos.y - this.transform.position.y, targetPos.x - this.transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;

        if(!isCollision)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, angleDeg);
            velocity = targetPos - transform.position;
        }

        velocity = velocity + GetComponent<CollisionAvoidance>().Avoidance();

//        velocity.x = Mathf.Clamp(velocity.x, -0.5f, 0.5f);
//        velocity.y = Mathf.Clamp(velocity.y, -0.5f, 0.5f);

        velocity.z = transform.position.z;
        transform.position = transform.position + velocity * Time.deltaTime * speed;
//        rb.MovePosition(transform.position + velocity * Time.deltaTime * speed);
    }
}
