using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIcon : MonoBehaviour
{
    public CharacterIconParent slots;
    public string icon;

    public void OnClick()
    {
        slots.GetSmallestSlot().SetCharacter(icon);
    }
}
