using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterIcon : MonoBehaviour
{
    public PlayerInventory inventory;
    public string iconName;

    void Awake()
    {
        inventory = GameObject.FindWithTag("Inventory").GetComponent<PlayerInventory>();
    }
    public void OnClick()
    {
        inventory.TryAddCharacter(iconName);
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
