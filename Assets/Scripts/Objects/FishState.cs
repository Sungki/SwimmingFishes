using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishState : FishObject
{
    public State curr;
    FollowTarget ft;
    Rigidbody2D rb;

    private void Start()
    {
        curr = State.Idle;
        ft = GetComponent<FollowTarget>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        switch(curr)
        {
            case State.Idle:
                Idle();
                break;
            case State.Move:
                Move();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Stun:
                Stun();
                break;
        }
    }

    public override void Stun()
    {
    }

    public override void Idle()
    {

    }
    public override void Move()
    {

    }

    public override void Attack()
    {

    }

    public void StartIdle()
    {
        curr = State.Idle;
        ft.enabled = true;
        rb.velocity = Vector2.zero;
    }

    public void StartStun()
    {
        Invoke("StartIdle", 1f);
        curr = State.Stun;
    }
}
