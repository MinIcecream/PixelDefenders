using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    public KnightManager knightManager;
    string type;

    //crossbower
    public GameObject bolt;

    //calvalry
    public Rigidbody2D rb;
    public FaceOpponent faceEnemy;
    public GameObject spear;

    //catapult
    public GameObject boulder;

    void Awake()
    {
        type = knightManager.knight.name;
    }

    public IEnumerator AttackDuration(float attackDuration, int damage)
    {
        if (type == "Crossbower")
        {
            yield return new WaitForSeconds(knightManager.attackTime);

            var newBolt = Instantiate(bolt, transform.position, Quaternion.identity);
            if (knightManager.currentTarget)
            {
                newBolt.GetComponent<CrossbowBolt>().Propel(knightManager.currentTarget, knightManager.knight.damage);
            }

            yield return new WaitForSeconds(attackDuration);
            knightManager.isAttacking = false;
        }
        else if (type == "Catapult")
        {
            yield return new WaitForSeconds(knightManager.attackTime);

            var newBoulder = Instantiate(boulder, transform.position, Quaternion.identity);
            if (knightManager.currentTarget)
            {
                newBoulder.GetComponent<CatapultBoulder>().Propel(knightManager.currentTarget, knightManager.knight.damage);
            }

            yield return new WaitForSeconds(attackDuration);
            knightManager.isAttacking = false;
        }

        else if (type == "Calvalry")
        {
            Vector2 target = Vector2.zero;
            float attackLength = knightManager.attackTime;
            float startTime = 0;
            bool attack = true;

            if (knightManager.currentTarget)
            {
                target = (knightManager.currentTarget.transform.position - transform.position).normalized;
            }

            faceEnemy.enabled = false;
            startTime = Time.time;
            spear.SetActive(true);

            while (attack)
            {
                rb.AddForce(target * 20, ForceMode2D.Force);
                if(Time.time - startTime >= attackLength)
                {
                    rb.velocity = Vector2.zero;
                    attack = false;
                }
                yield return null;
            }
            faceEnemy.enabled = true;
            spear.SetActive(false);

            yield return new WaitForSeconds(attackDuration);
            knightManager.isAttacking = false;
             
        }

        else
        {
            yield return new WaitForSeconds(knightManager.attackTime);

            if (knightManager.currentTarget)
            {
                knightManager.currentTarget.GetComponent<EnemyHealth>().DealDamage(damage);
            }
             
            yield return new WaitForSeconds(attackDuration);
            knightManager.isAttacking = false;
        }
    }
}
