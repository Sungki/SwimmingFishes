using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoidance : MonoBehaviour
{
    const float MAX_SEE_AHEAD = 3f;
    public GameObject obstacle;

    FollowTarget ft;
    void Start()
    {
        ft = GetComponent<FollowTarget>();
    }


    public Vector3 Avoidance()
    {
        if (!obstacle) return Vector3.zero;

        Vector3 avoidance_force = Vector3.zero;
        Vector3 ahead = transform.position + ft.velocity.normalized * MAX_SEE_AHEAD;
        if (Vector2.Distance(ahead, obstacle.transform.position) < obstacle.GetComponent<CircleCollider2D>().radius)
        {
//            ft.isCollision = true;
            avoidance_force = ahead - obstacle.transform.position;
            avoidance_force = avoidance_force.normalized;

            Invoke("ReStart", 0.3f);
        }

        return avoidance_force;
    }

/*    void Update()
    {
        Vector3 ahead = transform.position + ft.velocity.normalized * MAX_SEE_AHEAD;

//        Debug.DrawLine(transform.position, ahead, Color.red);

        if (Vector2.Distance(ahead, obstacle.transform.position) < obstacle.GetComponent<CircleCollider2D>().radius)
        {
            ft.isCollision = true;
            Vector3 avoidance_force = ahead - obstacle.transform.position;
            ft.velocity += avoidance_force.normalized;

            //            Debug.DrawLine(transform.position, ft.velocity, Color.blue);
//            Invoke("ReStart", 0.3f);
        }
    }
    */
    void ReStart()
    {
//        ft.isCollision = false;
    }
}
