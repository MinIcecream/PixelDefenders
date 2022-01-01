using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorMessage : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public float dissapearRate;

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
        Color newColor = tmp.faceColor;
        newColor.a -=dissapearRate;
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
