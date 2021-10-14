using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static GameObject[] chars = new GameObject[6];
    public GameObject[] slots = new GameObject[6];
    public GameObject selectedChar;

    void Start()
    {
        if(chars[0] != null)
        {
            selectedChar = chars[0];
        }
  
        for (int i = 0; i <6; i++)
        {
            if (chars[i] != null)
            {
                slots[i].GetComponent<InventorySlot>().SetImage(chars[i].name);
            }
            
        }
    }

    public void SetActiveChar(int slotNum)
    {
        if (chars[slotNum - 1] != null)
        {
            selectedChar = chars[slotNum - 1];
        }
    }

    public void SetCharacters()
    {
        int i = 0;
        foreach(string name in CharacterIconParent.Characters())
        {
            if (name != "")
            {
                chars[i] = Resources.Load<GameObject>("Unit Prefabs/" + name);
                slots[i].GetComponent<InventorySlot>().SetImage(chars[i].name);
            }
            i++;
        }
    }
}
