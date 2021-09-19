using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthBar : MonoBehaviour
{
    public EnemyHealth health;
    public Slider healthUI;
    public LevelManager man;
    public bool destroyed = false;

    void Awake()
    {
        health.SetMaxHealth(100);
        man = GameObject.FindWithTag("LevelManager").GetComponent<LevelManager>();
        healthUI = GameObject.FindWithTag("HealthUI").GetComponent<Slider>();
    }
    void Update()
    {
        healthUI.value = health.GetHealth();

        if (!destroyed)
        {
            if (health.GetHealth() <= 0)
            {
                StartCoroutine(man.LoadLoseScreen());
                GetComponent<Animator>().SetTrigger("Destroy");
                destroyed = true;
            }
        }
    }
}
