using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FishData", menuName = "FishData", order = 1)]
public class Fish : ScriptableObject
{
    public int speed;
    public int attackDamage;
    public int attackSpeed;
    public int health;
    public float attackDelay;

    public Sprite sprite;
}
