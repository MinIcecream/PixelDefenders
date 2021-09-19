using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalvalrySpear : MonoBehaviour
{
    public KnightManager manager;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name != "Castle")
        {
            if (coll.gameObject.transform.parent.tag == "Ogre")
            {
                coll.gameObject.transform.parent.GetComponent<EnemyHealth>().DealDamage(manager.knight.damage);
            }
        }
    }
}
