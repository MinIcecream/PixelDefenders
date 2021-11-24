using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorMessage : MonoBehaviour
{
    public TextMeshProUGUI tmp;


    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        Color newColor = tmp.faceColor;
        newColor.a -=0.008f;
        tmp.faceColor = newColor;
        if(newColor.a <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetText(string message)
    {
        tmp.text = message;
    }
}
