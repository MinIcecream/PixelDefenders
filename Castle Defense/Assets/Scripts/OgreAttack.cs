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
    public GameObject club;

    void Awake()
    {
        type = orcManager.ogre.name;
    }

    public IEnumerator AttackDuration(float attackDuration, int damage)
    {
        if (type == "Orc Druid")
        {
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
            yield return new WaitForSeconds(orcManager.attackTime);
            club.SetActive(true);
 
            yield return new WaitForSeconds(attackDuration);
            club.SetActive(false);
            orcManager.isAttacking = false;
        }

        else
        {
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
