using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceOpponent : MonoBehaviour
{
    GameObject target;
    public GameObject parent;

    void Update()
    {
        if (parent.tag == "Knight")
        {
            if(target = parent.GetComponent<KnightManager>().currentTarget)
            {
                target = parent.GetComponent<KnightManager>().currentTarget;
            }
        }
        else if (parent.tag == "Ogre")
        {
             
            if (target = parent.GetComponent<OgreManager>().currentTarget)
            {
                target = parent.GetComponent<OgreManager>().currentTarget;
            }
        }

        if (target)
        {
            if (target.transform.position.x >= transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }  
    }
}
