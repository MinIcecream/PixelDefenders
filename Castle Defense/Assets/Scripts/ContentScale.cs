using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentScale : MonoBehaviour
{
    void Start()
    {
        //get heigh of canvas.
        float canvasHeight = GameObject.FindWithTag("Canvas").GetComponent<RectTransform>().rect.height ;

        //what pct of the scale should the content be????? idk lol
        float pct = (canvasHeight / 3.7f) * 0.01f;

        GetComponent<RectTransform>().localScale = new Vector2(pct, pct);
    }
}
