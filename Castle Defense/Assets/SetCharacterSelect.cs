using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacterSelect : MonoBehaviour
{
    public GameObject characterImage;

    void Awake()
    {
        foreach(Sprite sprite in Resources.LoadAll("Units", typeof(Sprite)))
        {
            var newChar = Instantiate(characterImage, transform.position, Quaternion.identity);

            newChar.transform.SetParent(this.gameObject.transform);
            newChar.GetComponent<Image>().overrideSprite = sprite;
        }
    }
}
