using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingParticles : MonoBehaviour
{
    public float dissapearRate;
    SpriteRenderer ren;

    void Awake()
    {
        ren = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 1*Time.deltaTime);
        Color newColor = ren.color;
        newColor.a -= dissapearRate;
        ren.color = newColor;
        if (newColor.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
