using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonID : MonoBehaviour
{
    public int num;

    public void SetID(int newNum)
    {
        num = newNum;
    }
    public int GetID()
    {
        return num;
    }
}
