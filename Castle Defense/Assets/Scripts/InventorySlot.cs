using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public GameObject image,text;
    public PlayerInventory invenMan;
    [Range(1,7)]
    public int slotNum;
    private string character;

    //CHARAcTER SELECT
    
    public void SetCharacter(string newCharacter)
    {
        image.SetActive(true);
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/" + newCharacter);
        character = newCharacter;

        text.GetComponent<TextMeshProUGUI>().text = Resources.Load<Unit>("Unit Info/" + character).cost.ToString();

    }
    public void ResetSlot()
    {
        image.SetActive(false);
        character = "";
    }
    
    public void SetActiveSlot()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(70, 70);
    }

    public void SetInactiveSlot()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(64, 64);
    }

    public void Clicked()
    {
        AudioManager.Play("Click");
        if(character != "")
        {
            invenMan.ResetSlots();
            SetActiveSlot();
            invenMan.SetActiveCharacter(character);
        }
    }
 
}
