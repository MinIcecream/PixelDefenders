using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class Unit : ScriptableObject
{
    public int cost;
    public int health;
    public int damage;
    public float range;
    public float movement;
    public float attackDuration;
}
