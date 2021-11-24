using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        slots.SetCharacterInSmallestSlot(this.gameObject);
    }

    public void SetAlpha()
    {
        Color c = GetComponent<Image>().color;
        c.a = 0.5f;
        GetComponent<Image>().color = c;
    }
    public void ResetAlpha()
    {
        Color c = GetComponent<Image>().color;
        c.a = 1;
        GetComponent<Image>().color = c;
    }
}
