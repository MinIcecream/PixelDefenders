using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcSpell : MonoBehaviour
{
    GameObject enemy;
    int damage;
    public GameObject particles;
    Vector3 dir;
    float speed = 2f;

    public void SetTarget(GameObject target, int setDamage)
    {
        Vector2 startPos = transform.position;
        Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
        enemy = target;
        damage = setDamage;
        dir = (targetPos - startPos).normalized;
    }
    void Awake()
    {
        Invoke("Destroy", 10f);
    }
    void FixedUpdate()
    {
        if(dir != null)
        {
            transform.position += dir * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
       if(enemy != null)
       {
            if (enemy.tag == "Castle")
            {
                if (coll.gameObject == enemy)
                {
                    enemy.GetComponent<EnemyHealth>().DealDamage(damage);
                    GetComponent<SpriteRenderer>().enabled = false;
                    particles.GetComponent<ParticleSystem>().Play();
                    Invoke("Destroy", 1f);
                }
            }
            else
            {
                if (coll.gameObject.transform.parent.gameObject == enemy)
                {
                    enemy.GetComponent<EnemyHealth>().DealDamage(damage);
                    GetComponent<SpriteRenderer>().enabled = false;
                    particles.GetComponent<ParticleSystem>().Play();
                    Invoke("Destroy", 1f);
                }
            }
       }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
