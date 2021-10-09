using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectSlot : MonoBehaviour
{
    public GameObject character;

    public void SetCharacter(GameObject selectedChar)
    {
        character = selectedChar;
    }
 

    // Update is called once per frame
    void Update()
    {
        
    }
}
