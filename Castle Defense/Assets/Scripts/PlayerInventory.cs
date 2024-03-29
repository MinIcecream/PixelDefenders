using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<string>chars = new List<string>();
    public GameObject[] slots = new GameObject[7];
    public GameObject[] iconSelectionSlots = new GameObject[7];
    public string selectedChar;
    
    void Start()
    {
        UpdateAllSlots();
    }
    /*
    //CHARACTER SELECT
    
     
    //tries to add character to lowest slot available
    public void TryAddCharacter(string character, GameObject slot)
    {
        for (int j = 0; j < 6; j++)
        {
            if(chars[j] == character)
            {
                return;
            }
        }
        for (int i = 0; i < 6; i++)
        {
            if(chars[i] == "")
            {
                slot.GetComponent<CharacterIcon>().SetAlpha();
                chars[i] = character;
                UpdateAllSlots();
                return;
            }
        }
    }

    //finds character and removes it
    public void RemoveCharacter(string character)
    {
        for (int i = 0; i < 6; i++)
        {
            if (chars[i] == character)
            {
                chars[i]="";
                UpdateAllSlots();
                return;
            }
        }
    }
    */
    //update icon selection bar and inventory bar
    public void UpdateAllSlots()
    {
        for (int i =0; i<7; i++)
        {
            slots[i].GetComponent<InventorySlot>().ResetSlot();
           // iconSelectionSlots[i].GetComponent<CharacterIconSlot>().ResetSlot();

            if (chars[i] != "")
            {
                slots[i].GetComponent<InventorySlot>().SetCharacter(chars[i]);
               // iconSelectionSlots[i].GetComponent<CharacterIconSlot>().SetCharacter(chars[i]);
            }
        }
    }
    
    public void SetActiveCharacter(string selectedCharacter)
    {
        selectedChar = selectedCharacter;
    }
    public void ResetSlots()
    {
        for(int i = 0; i < 7; i++)
        {
            slots[i].GetComponent<InventorySlot>().SetInactiveSlot();
        }
    }
}
