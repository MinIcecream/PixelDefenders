using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIconSlot : MonoBehaviour
{
    public string character;
    public GameObject button;
    public PlayerInventory invenMan;

    void Awake()
    {
        invenMan = GameObject.FindWithTag("Inventory").GetComponent<PlayerInventory>();
    }

    public void SetCharacter(string newCharacter)
    {
        character = newCharacter;
        GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Units/" + newCharacter);
        button.SetActive(true);
    }
    public void ResetSlot()
    {
        character = "";
        GetComponent<Image>().overrideSprite = null;
        button.SetActive(false);
    }

    public void ResetSlotButtonOnClick()
    {
        invenMan.RemoveCharacter(character);
    }
}
