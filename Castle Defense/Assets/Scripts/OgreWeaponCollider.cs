using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreWeaponCollider : MonoBehaviour
{
    public OgreManager manager;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag != "Castle")
        {
            if (coll.gameObject.transform.parent.tag == "Knight")
            {
                coll.gameObject.transform.parent.GetComponent<EnemyHealth>().DealDamage(manager.ogre.damage);
            }
        }
        else
        {
            coll.gameObject.GetComponent<EnemyHealth>().DealDamage(manager.ogre.damage);
        }
    }
}
