using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDragCharacter : MonoBehaviour
{
    int bitmask = 1 << 13;

    bool dragging = false;

    GameObject hitObject;

    bool objChosen = false;
 
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, bitmask);
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (hit.collider != null)
        {
            if (objChosen == false)
            {
                hitObject = hit.collider.gameObject;
            }

            objChosen = true;

            if (Input.GetMouseButtonDown(0))
            {
                dragging = true;
            }
        }
        else
        {
            if (dragging == false)
            {
                objChosen = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            objChosen = false;
            hitObject = null;
        }


        if (dragging && hitObject != null)
        {
            if (hitObject.GetComponent<MoveWithDrag>() != null)
            {
                hitObject.GetComponent<MoveWithDrag>().drag = true;
            }
        }
    }
}
