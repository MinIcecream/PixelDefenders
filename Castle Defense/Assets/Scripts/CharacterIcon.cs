using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIcon : MonoBehaviour
{
    public CharacterIconParent slots;
    public string icon;

    void Awake()
    {
        slots = GameObject.FindWithTag("SlotManager").GetComponent<CharacterIconParent>();
    }
    public void OnClick()
    {
        slots.SetCharacterInSmallestSlot(icon);
    }
}
