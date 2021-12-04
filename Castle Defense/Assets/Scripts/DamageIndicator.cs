using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    public static IEnumerator SetDamageColor(GameObject target)
    {
        if(target.tag == "Castle")
        {
            yield break;
        }
 
        if (target != null)
        {
            target.transform.Find("Sprite").GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        }
        yield return new WaitForSeconds(0.2f);

        if (target != null) 
        {

            target.transform.Find("Sprite").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        } 
    }
}

