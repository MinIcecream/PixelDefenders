using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneCardScale : MonoBehaviour
{
    public bool locked;
    public GameObject lockPoint;
    public float dist;

    void Awake()
    {
        lockPoint = GameObject.FindWithTag("LockPoint");
    }
    void FixedUpdate()
    {
        dist = Mathf.Abs(lockPoint.transform.position.x- transform.position.x);
        if (dist< 200)
        {

            float distPct = (100 - (dist / 2)) * 0.01f; 

            float convertSize = .7f + (distPct * 0.09f);

            Vector3 targetSize = new Vector3(convertSize, convertSize, convertSize);
 
            Vector3 newPos = targetSize - transform.localScale;
            transform.localScale += newPos;
         //   locked = true;
        }
        else
        {
            transform.localScale = new Vector2(0.7f,0.7f);
        }
    }
}
