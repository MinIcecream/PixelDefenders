using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreManager : MonoBehaviour
{
    public GameObject currentTarget;
    public GameObject castle;
    public FieldOfView FOV;
    public Rigidbody2D rb;
    public bool idle, isAttacking;
    public Animator anim;
    public EnemyHealth health;

    public Unit ogre;
    public float attackTime;

    public OgreAttack attackManager;

    void Start()
    {
        Invoke("SetCastle", 0.5f);
  
        health.SetMaxHealth(ogre.health);
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
    void SetCastle()
    {
        castle = GameObject.FindWithTag("Castle");

        currentTarget = castle;
    }

    void Update()
    {
        if (health.GetHealth() <= 0)
        {

            PopupManager.SpawnDeathParticles(gameObject);
            GameObject.FindWithTag("Player").GetComponent<CoinManager>().AddGold(ogre.cost);
            Destroy(gameObject);
        }
        //UPDATE CURRENT TARGET
        
        if (FOV.newTarget != null)
        {
            idle = false;

            currentTarget = FOV.newTarget;
                
        }
        else if (castle != null && castle.GetComponent<UpdateHealthBar>().destroyed == false)
        {
            currentTarget = castle;
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
            if (Vector3.Distance(transform.position, currentTarget.transform.position) < ogre.range)
            {
                isAttacking = true;
                anim.SetTrigger("Attack");
                StartCoroutine(attackManager.AttackDuration(ogre.attackDuration, ogre.damage));
            }
            else
            {
                Vector2 dir;

                anim.SetTrigger("Walk");
                dir = currentTarget.transform.position - transform.position;
                dir.Normalize();
                rb.MovePosition(rb.position + dir * ogre.movement * Time.deltaTime);
            }
             
        }
    }
}

