using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultBoulderAOECollider : MonoBehaviour
{
    public ArrayList enemies = new ArrayList();

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == null)
        {
            return;
        }
          enemies.Add(coll.gameObject.transform.parent.gameObject);
        
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject == null)
        {
            return;
        }
        enemies.Remove(coll.gameObject.transform.parent.gameObject); 
    }
}
