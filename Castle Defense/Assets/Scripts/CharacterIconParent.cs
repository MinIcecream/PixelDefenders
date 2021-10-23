using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIconParent : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();
    private static List<string> characters = new List<string>();

    public void SetCharacterInSmallestSlot(GameObject newChar)
    {
        if (!characters.Contains(newChar.GetComponent<CharacterIcon>().icon))
        {
            foreach (GameObject slot in slots)
            {
                if (slot.GetComponent<CharacterIconSlot>().character == "")
                {
                    slot.GetComponent<CharacterIconSlot>().SetCharacter(newChar);
                    characters.Add(newChar.GetComponent<CharacterIcon>().icon);
                    break;
                }
            }
        }
    }
    public static void RemoveCharacterFromList(string charToRemove)
    {
        characters.Remove(charToRemove);
    }
    public static List<string> Characters()
    {
        return characters;
    }
}
