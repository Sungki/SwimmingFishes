using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;
    [HideInInspector] public Vector3 velocity;

//    public bool isCollision = false;

    /*    Rigidbody2D rb;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }*/

    Vector3 targetPos;

    void Update()
    {
        targetPos = target.transform.position;
        float angleRad = Mathf.Atan2(targetPos.y - this.transform.position.y, targetPos.x - this.transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, angleDeg);
    }

    private void FixedUpdate()
    {
//        targetPos = target.transform.position;
        velocity = targetPos - transform.position;

        //        velocity = velocity + GetComponent<CollisionAvoidance>().Avoidance();

        velocity.x = Mathf.Clamp(velocity.x, -0.9f, 0.9f);
        velocity.y = Mathf.Clamp(velocity.y, -0.9f, 0.9f);

        velocity.z = transform.position.z;
        transform.position = transform.position + velocity * Time.deltaTime * speed;
        //        rb.MovePosition(transform.position + velocity * Time.deltaTime * speed);        
    }
}
