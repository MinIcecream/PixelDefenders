using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacterSelect : MonoBehaviour
{
    public GameObject characterImage;

    void Awake()
    {
        foreach (string name in UnitManager.PlayerUnits())
        {
            var newChar = Instantiate(characterImage, transform.position, Quaternion.identity);

            newChar.transform.SetParent(this.gameObject.transform);
            newChar.GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/"+name);
            newChar.GetComponent<CharacterIcon>().icon = name;
        }
    }
}
