using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FishObject : MonoBehaviour
{
    public enum State
    {
        Idle,
        Move,
        Attack,
        Stun
    }

    public abstract void Idle();
    public abstract void Move();
    public abstract void Attack();
    public abstract void Stun();
}
