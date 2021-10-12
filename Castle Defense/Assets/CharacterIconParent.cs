using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIconParent : MonoBehaviour
{
    public CharacterIconSlot slot1, slot2, slot3, slot4, slot5, slot6;

    public CharacterIconSlot GetSmallestSlot()
    {
        if(slot1.character == null)
        {
            Debug.Log("JJ");
            return slot1;
        }
        else if (slot2.character == null)
        {
            return slot2;
        }
        else if (slot3.character == null)
        {
            return slot3;
        }
        else if (slot4.character == null)
        {
            return slot4;
        }
        else if (slot5.character == null)
        {
            return slot5;
        }
        else if (slot6.character == null)
        {
            return slot6;
        }
        else
        {
            return null;
        }
    }
}
