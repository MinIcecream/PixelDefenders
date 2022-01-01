using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageTreePosition : MonoBehaviour
{
    public GameObject top, right, left, bottom; 

    void Start()
    {
        Vector2 tmpPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        left.transform.position = new Vector2(-tmpPos.x, 0);
        right.transform.position = new Vector2(tmpPos.x, 0);
        top.transform.position = new Vector2(0, tmpPos.y);
        bottom.transform.position = new Vector2(0, -tmpPos.y);
    }

}
