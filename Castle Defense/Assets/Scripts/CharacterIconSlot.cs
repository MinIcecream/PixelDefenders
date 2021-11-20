using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIconSlot : MonoBehaviour
{
    public string character;
    public GameObject button;
    GameObject unitObject;

    public void SetCharacter(GameObject chosenChar)
    {
        character = chosenChar.GetComponent<CharacterIcon>().icon;
        GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Units/" + character);
        button.SetActive(true);

        //set alpha smaller
        unitObject = chosenChar;
        unitObject.GetComponent<CharacterIcon>().SetAlpha();
 
    }
    public void ResetSlot()
    {
        if (character!="")
        {
            CharacterIconParent.RemoveCharacterFromList(character);
            character = "";
            GetComponent<Image>().overrideSprite = null;
            button.SetActive(false);

            //reset alpha
            unitObject.GetComponent<CharacterIcon>().ResetAlpha();
        }
 
    }
}
