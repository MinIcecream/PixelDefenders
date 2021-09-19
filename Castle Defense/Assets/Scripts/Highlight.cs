using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Material normal;

    public Material outline;

    bool shouldHighlight = false;

    public void OutlineObject()
    {
        shouldHighlight = true;
    }

    void Update()
    {
        if (shouldHighlight)
        {
            GetComponent<SpriteRenderer>().material = outline;
        }
        else
        {
            GetComponent<SpriteRenderer>().material = normal;
        }
        shouldHighlight = false;
    }
}
