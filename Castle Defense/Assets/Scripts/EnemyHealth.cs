using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int health;

    public int GetHealth()
    {
        return health;
    }
    public void DealDamage(int damage)
    {
        health -= damage;
    }

    public void GainHealth(int gain)
    {
        health += gain;
    }

    public void SetMaxHealth(int max)
    {
        health = max;
    }
}
