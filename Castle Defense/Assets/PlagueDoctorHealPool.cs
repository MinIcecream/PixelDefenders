using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueDoctorHealPool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator Heal()
    {
        yield return new WaitForSeconds(1f);
    }
}
