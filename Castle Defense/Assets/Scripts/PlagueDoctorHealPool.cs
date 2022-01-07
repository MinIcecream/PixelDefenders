using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueDoctorHealPool : MonoBehaviour
{
    ArrayList colls = new ArrayList();

    int rate;
    public float dissapearSpeed;
    float lifeSpan;

    void Start()
    {
        StartCoroutine(Tick());
        lifeSpan = 1;
    }

    public void SetDamageAndHeal(int point)
    {
         rate = point;
    }
    public IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Action();
        }
    }

    void Update()
    {
        lifeSpan -= dissapearSpeed * Time.deltaTime;

        Color newColor = GetComponent<SpriteRenderer>().color;
        newColor.a = lifeSpan;
        GetComponent<SpriteRenderer>().color = newColor;

        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Action()
    {
        foreach(GameObject obj in colls)
        {
            GameObject unit = obj.transform.parent.gameObject;

            if(unit.tag == "Knight")
            {
                unit.GetComponent<EnemyHealth>().GainHealth(rate);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        colls.Add(collider.gameObject);
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        colls.Remove(collider.gameObject);
    }
}
