using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointer : MonoBehaviour
{
    public enum state
    {
        shrinking,
        growing
    }
    public bool visible = true;

    state pointerState = state.growing;

    public GameObject target;

    public LevelManager man;

    bool nearbyNeighborFound = false;

    void Awake()
    {
        man = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
    }
    void Update()
    {
        CheckToDestroy();
        if(target != null)
        {
            UpdateState();
            UpdateRotation();
            FollowTarget();
            MergeWithOtherPointers();
        }

        float sizeToChangeBy = 0.5f * Time.deltaTime;

        switch (pointerState)
        {
            case (state.shrinking):
                transform.localScale -= new Vector3(sizeToChangeBy, sizeToChangeBy, sizeToChangeBy);
                break;

            case (state.growing):
                transform.localScale += new Vector3(sizeToChangeBy, sizeToChangeBy, sizeToChangeBy);
                break;
        }
    }

    void UpdateState()
    {
        if(transform.localScale.x > 1.15f)
        {
            pointerState = state.shrinking;
        }
        else if (transform.localScale.x < 0.85f)
        {
            pointerState = state.growing;
        }
    }

    void CheckToDestroy()
    {
        if(target != null)
        {
            Vector3 targetPos = Camera.main.WorldToViewportPoint(target.transform.position);
            if (targetPos.x > 0 && targetPos.x < 1 && targetPos.y > 0 && targetPos.y < 1)
            {

                man.pointers.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
        }
        else
        {
            man.pointers.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    void FollowTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 2f * Time.deltaTime);
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -9f, 10f);
        pos.y = Mathf.Clamp(transform.position.y, -6f, 4f);
        transform.position = pos;
    }

    void UpdateRotation()
    {
        transform.up = target.transform.position - transform.position;
    }

    void MergeWithOtherPointers()
    {
        foreach(GameObject pointer in man.pointers)
        {
            if (pointer)
            {
                if (pointer.GetComponent<EnemyPointer>().visible == true)
                {
                    if (pointer != gameObject)
                    {
                        if (Vector2.Distance(transform.position, pointer.transform.position) < 2)
                        {
                            nearbyNeighborFound = true;
                            GetComponent<SpriteRenderer>().enabled = false;
                            visible = false;
                        }
                    }
                }

            }   
        }
        if(nearbyNeighborFound == false)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            visible = true;
        }
        nearbyNeighborFound = false;
    }
}
