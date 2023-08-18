using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreAttack : MonoBehaviour
{
    public OgreManager orcManager;
    string type;

    //druid
    public GameObject spell;

    //giant
    public GameObject club, slamParticles;

    //assassin
    public GameObject smoke;

    void Awake()
    {
        type = orcManager.ogre.name;
    }

    public IEnumerator AttackDuration(float attackDuration, int damage)
    {
        if (type == "Orc Druid")
        {
            orcManager.anim.SetTrigger("Attack");
            yield return new WaitForSeconds(orcManager.attackTime);

            var newSpell = Instantiate(spell, transform.position, Quaternion.identity);
            if (orcManager.currentTarget)
            {
                newSpell.GetComponent<OrcSpell>().SetTarget(orcManager.currentTarget, orcManager.ogre.damage);
            }

            yield return new WaitForSeconds(attackDuration);
            orcManager.isAttacking = false;
        }

        else if (type == "Orc Giant")
        {
            orcManager.anim.SetTrigger("Attack"); 
            yield return new WaitForSeconds(orcManager.attackTime-.4f);
            club.SetActive(true); 

            yield return null;
            club.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            Instantiate(slamParticles, new Vector2(transform.position.x, transform.position.y - .55f), Quaternion.identity);

            yield return new WaitForSeconds(attackDuration); 
            orcManager.isAttacking = false;
        }

        else if (type == "Orc Assassin")
        {
            if (Vector3.Distance(transform.position, orcManager.currentTarget.transform.position) <1f)
            {
                orcManager.anim.SetTrigger("Attack");

                yield return new WaitForSeconds(orcManager.attackTime); 
                if (orcManager.currentTarget)
                {
                    orcManager.currentTarget.GetComponent<EnemyHealth>().DealDamage(damage);
                }
            }
            else
            {
                orcManager.anim.SetTrigger("Dash");

                yield return new WaitForSeconds(orcManager.attackTime);
                Vector2 targetPos = orcManager.currentTarget.transform.position;

                Instantiate(smoke, transform.position, Quaternion.identity);
                transform.position = targetPos;
            }
            yield return new WaitForSeconds(attackDuration);
            orcManager.isAttacking = false;
        }

        else
        {
            orcManager.anim.SetTrigger("Attack");
            yield return new WaitForSeconds(orcManager.attackTime);

            if (orcManager.currentTarget)
            {
                orcManager.currentTarget.GetComponent<EnemyHealth>().DealDamage(damage);
            }

            yield return new WaitForSeconds(attackDuration);
            orcManager.isAttacking = false;
        }
    }
}
