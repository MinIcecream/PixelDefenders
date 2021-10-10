using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithDrag : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    Vector3 cursorPosition;
    Vector3 cursorScreenPoint;

    public bool drag = false;

    public Camera cam;
    //public Rigidbody2D rb;

    void Awake()
    {
        Debug.Log(transform.position);
    }
    void LateUpdate()
    {
        if (drag)
        {
            Debug.Log("OK");
            /*Vector3 pos = Input.mousePosition;
            pos.z = Vector3.Distance(transform.position, cam.transform.position);
            pos = cam.ScreenToWorldPoint(pos);
            rb.velocity = (pos - transform.position) * 5;*/
            Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(pos.x, pos.y);
        }
        drag = false;
    }
}
