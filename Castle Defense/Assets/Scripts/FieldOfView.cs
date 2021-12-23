using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    [Range(0, 360)]
    public float viewDirection;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    public GameObject newTarget;

    void Start()
    {
        FindVisibleTargets();
        StartCoroutine("FindTargetWithDelay", 0.2f);
    }

    IEnumerator FindTargetWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    //Finds targets inside field of view not blocked by walls
    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        //Adds targets in view radius to an array
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);
        //For every targetsInViewRadius it checks if they are inside the field of view
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            if(visibleTargets.Count > 0)
            {
               // return;
            }
            else
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;

                if ((Vector2.Angle(-transform.right, dirToTarget)) < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.position);
                    //If line draw from object to target is not interrupted by wall, add target to list of visible 
                    //targets
                    if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                    {
                        if(target != this.gameObject.transform)
                        {

                            visibleTargets.Add(target);

                        }
                    }
                }
            }
             
        }
        if(visibleTargets.Count > 0)
        {
            for (int i = 0; i < visibleTargets.Count; i++)
            {
                float closestDist = 100f;

                float dist = Vector3.Distance(transform.position, visibleTargets[i].transform.position);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    newTarget = visibleTargets[i].gameObject;
                }
            }
        }
        else
        {
            newTarget = null;
        }
    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            if (transform.eulerAngles.y == 0)
            {
                angleInDegrees -= transform.eulerAngles.z + viewDirection;
            }
            else
            {
                angleInDegrees -= transform.eulerAngles.z + viewDirection + 180;
            }

        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }
}
