using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultBoulder : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject enemy;
    int damage;
    public CatapultBoulderAOECollider targets;

    public void Propel(GameObject target, int setDamage)
    {
        if (target != null)
        {
            Vector2 startPos = transform.position;
            Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.y + 1f);
            enemy = target;
            damage = setDamage;
            rb.AddForce((targetPos - startPos) * 2, ForceMode2D.Impulse);
            Invoke("Destroy", 5f);
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag != "Castle")
        {
             
            if (coll.gameObject.transform.parent.gameObject == enemy)
            {
                foreach (GameObject enemy in targets.enemies)
                {
                    enemy.GetComponent<EnemyHealth>().DealDamage(damage);
                }
                rb.velocity = Vector3.zero;
                rb.gravityScale = 0f;
                rb.GetComponent<SpriteRenderer>().enabled = false;
                rb.GetComponent<CircleCollider2D>().enabled = false;
                Invoke("Destroy", 1f);
            }
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
