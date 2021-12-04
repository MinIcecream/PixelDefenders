using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int health;
    int max;

    public int GetHealth()
    {
        return health;
    }
    public void DealDamage(int damage)
    {
        health -= damage;
        StartCoroutine(DamageIndicator.SetDamageColor(this.gameObject));
    }

    public void GainHealth(int gain)
    {
        if(health+gain >= max)
        {
            health = max;
        }
        else
        {
            health += max;
        }
    }

    public void SetMaxHealth(int value)
    {
        health = value;
        max = value;
    }
}
