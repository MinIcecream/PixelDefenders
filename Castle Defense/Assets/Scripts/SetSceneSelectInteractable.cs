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
                card.transform.Find("Button").GetComponent<Button>().interactable = true;
            }
            else
            {
                card.transform.Find("Button").GetComponent<Button>().interactable = true;
                card.transform.Find("Lock").gameObject.SetActive(true);
            }
        }
    }
}
