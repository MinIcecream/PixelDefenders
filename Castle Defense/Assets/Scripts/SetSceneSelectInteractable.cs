using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSceneSelectInteractable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject card in GameObject.FindGameObjectsWithTag("SceneCard"))
        {
            if (card.GetComponent<ButtonID>().GetID() <= PlayerPrefs.GetInt("CompletedScene", 0) + 1)
            {
                card.transform.GetChild(5).GetComponent<Button>().interactable = true;
            }
            else
            {
                card.transform.GetChild(5).GetComponent<Button>().interactable = false;
                card.transform.GetChild(6).gameObject.SetActive(true);
            }
        }
    }
}
