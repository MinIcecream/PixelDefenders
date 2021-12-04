using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{

    public static void SpawnDeathParticles(GameObject trans)
    {
        Instantiate(Resources.Load<GameObject>("Spawnables/Death Particles"), trans.transform.position, Quaternion.identity);
    }
}
