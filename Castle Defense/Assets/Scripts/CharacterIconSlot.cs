using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIconSlot : MonoBehaviour
{
    public string character;
    public GameObject button;

    public void SetCharacter(string chosenChar)
    {
        character = chosenChar;
        GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Units/" + character);
        button.SetActive(true);
    }
    public void ResetSlot()
    {
        CharacterIconParent.RemoveCharacterFromList(character);
        character = "";
        GetComponent<Image>().overrideSprite = null;
        button.SetActive(false);
    }
}
