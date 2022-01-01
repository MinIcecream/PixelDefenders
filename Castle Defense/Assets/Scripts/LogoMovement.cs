using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoMovement : MonoBehaviour
{
    string state = "left";
    string sizeState = "small";
    void FixedUpdate()
    {
        //ROTATE
        if(state == "left")
        {
            transform.Rotate(0, 0, 0.3f);
            if(transform.localRotation.eulerAngles.z >= 20 && transform.localRotation.eulerAngles.z <= 340)
            {
                state = "right";
            }
        }
        else
        {
            transform.Rotate(0, 0, -0.3f);
            if (transform.localRotation.eulerAngles.z <= 340 &&transform.localRotation.eulerAngles.z>=20)
            {
                state = "left";
            }
        }

        //SIZE
        if(sizeState == "small")
        {
            transform.localScale = new Vector2(transform.localScale.x - 0.003f, transform.localScale.y - 0.003f);
            if(transform.localScale.x <= 0.9f)
            {
                sizeState = "big";
            }
        }
        else
        {
            transform.localScale = new Vector2(transform.localScale.x + 0.003f, transform.localScale.y + 0.003f);
            if (transform.localScale.x >= 1.1f)
            {
                sizeState = "small";
            }
        }
    }
}
