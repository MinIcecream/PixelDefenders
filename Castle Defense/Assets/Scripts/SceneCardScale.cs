using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneCardScale : MonoBehaviour
{
    public bool locked;
    public GameObject lockPoint;

    void Awake()
    {
        lockPoint = GameObject.FindWithTag("LockPoint");
    }
    void Update()
    {
        if(Vector2.Distance(lockPoint.transform.position, transform.position)< 200)
        {
            float dist = (Vector2.Distance(lockPoint.transform.position, transform.position));

            float distPct = (100 - (dist / 2)) * 0.01f; 

            float convertSize = .8f + (distPct * 0.4f);

            Vector3 targetSize = new Vector3(convertSize, convertSize, convertSize);
 
            Vector3 newPos = targetSize - transform.localScale;
            transform.localScale += newPos;
            locked = true;
        }
        else
        {
            locked = false;
        }
    }
}
