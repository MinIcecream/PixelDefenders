using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightManager : MonoBehaviour
{
    public GameObject currentTarget;
    public FieldOfView FOV;
    public Rigidbody2D rb;
    public bool idle, isAttacking;
    Vector2 dir;
    public Animator anim;
    public EnemyHealth health;

    public Unit knight;
    public float attackTime;

    public KnightAttack attackManager;
    //Crossbower only

    void Awake()
    {
        health.SetMaxHealth(knight.health);

        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Attack":
                    attackTime = clip.length;
                    break;
            }
        }
    }

    void Update()
    {
        if(health.GetHealth() <= 0)
        {
            PopupManager.SpawnDeathParticles(gameObject);
            Destroy(gameObject);
        }

        //UPDATE CURRENT TARGET
       
        if (FOV.newTarget != null)
        {
            currentTarget = FOV.newTarget;
            idle = false;    
        }
        else
        {
            idle = true;
        }
        
    }

    void FixedUpdate()
    {
        if (!idle && !isAttacking && currentTarget != null)
        {
            if (Vector3.Distance(transform.position, currentTarget.transform.position) < knight.range)
            {
                isAttacking = true;
                anim.SetTrigger("Attack");
                StartCoroutine(attackManager.AttackDuration(knight.attackDuration, knight.damage));
            }
            else
            {
                anim.SetTrigger("Walk");
                dir = currentTarget.transform.position - transform.position;
                dir.Normalize();
                rb.MovePosition(rb.position + dir * knight.movement * Time.deltaTime);
            }
        }
    }
}