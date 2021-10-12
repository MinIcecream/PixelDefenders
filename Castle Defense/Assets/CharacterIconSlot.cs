using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIconSlot : MonoBehaviour
{
    public string character;
   
    public void SetCharacter(string chosenChar)
    {
        character = chosenChar;
        gameObject.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Units/" + character);
    }
}
