using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDragCharacter : MonoBehaviour
{
    int bitmask = 1<<13;
    bool dragging = false;
    GameObject hitObject;
    bool objChosen = false;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

        }
    }
}
