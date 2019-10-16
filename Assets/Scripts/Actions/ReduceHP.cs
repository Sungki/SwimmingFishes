using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceHP : MonoBehaviour
{
    public int hp = 0;

    public void Hit()
    {
        hp--;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
