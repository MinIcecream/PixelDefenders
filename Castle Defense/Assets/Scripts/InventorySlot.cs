using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public GameObject image;
    public PlayerInventory invenMan;
    [Range(1,6)]
    public int slotNum;
    private string character;

    public void SetCharacter(string newCharacter)
    {
        image.SetActive(true);
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/" + newCharacter);
        character = newCharacter;
    }
    public void ResetSlot()
    {
        image.SetActive(false);
        character = "";
    }

    public void Clicked()
    {
        if(character != "")
        {
            invenMan.SetActiveCharacter(character);
        }
    }
 
}
