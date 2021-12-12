using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultBoulder : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject enemy;
    int damage;
   
    public void Propel(GameObject target, int setDamage)
    {
        Vector2 startPos = transform.position;
        Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.y + 1f);
        enemy = target;
        damage = setDamage;
        rb.AddForce((targetPos - startPos) * 2, ForceMode2D.Impulse);
        Invoke("Destroy", 5f);
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag != "Castle")
        {
            if (coll.gameObject.transform.parent.gameObject == enemy)
            {
                rb.velocity = Vector3.zero;
                rb.gravityScale = 0f;
                rb.GetComponent<SpriteRenderer>().enabled = false;
                rb.GetComponent<BoxCollider2D>().enabled = false;
            //    particles.GetComponent<ParticleSystem>().Play();
                enemy.GetComponent<EnemyHealth>().DealDamage(damage);
                Invoke("Destroy", 1f);
            }
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
