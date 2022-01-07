using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsate : MonoBehaviour
{
    public enum state
    {
        shrinking,
        growing
    }

    state pointerState = state.growing;

    void Start()
    {
        Debug.Log("start");
        StartCoroutine(ChangeSize());
    }


    void UpdateState()
    {
        if (transform.localScale.x > 1.15f)
        {
            pointerState = state.shrinking;
        }
        else if (transform.localScale.x < 0.85f)
        {
            pointerState = state.growing;
        }
    }

    IEnumerator ChangeSize() 
    {
        while (true)
        {
            UpdateState();

            float sizeToChangeBy = 0.004f;

            switch (pointerState)
            {
                case (state.shrinking):
                    transform.localScale -= new Vector3(sizeToChangeBy, sizeToChangeBy, sizeToChangeBy);
                    break;

                case (state.growing):
                    transform.localScale += new Vector3(sizeToChangeBy, sizeToChangeBy, sizeToChangeBy);
                    break;
            }
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
}
