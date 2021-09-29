using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectEnabler : MonoBehaviour
{
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        SpawnButtons();

        foreach (GameObject button in GameObject.FindGameObjectsWithTag("LevelButton"))
        {
            if(PlayerPrefs.GetInt("CompletedScene", 1) >= CurrentLevelManager.CurrentScene())
            {
                button.GetComponent<Button>().interactable = true;
            }
            else if (button.GetComponent<ButtonID>().GetID() <= PlayerPrefs.GetInt("CompletedLevel", 1))
            {
                button.GetComponent<Button>().interactable = true;
            }
            else
            {
                button.GetComponent<Button>().interactable = false;
            }
        }
    }

    void SpawnButtons()
    {
   
        for(int i = 1; i <= CurrentLevelManager.LevelsInCurrentScene(); i++)
        {
            var newButton = Instantiate(button, transform.position, Quaternion.identity);
 
            newButton.transform.SetParent(this.gameObject.transform);
            newButton.GetComponent<ButtonID>().SetID(i);
            newButton.name = (i).ToString();
            newButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (i).ToString();

            newButton.GetComponent<Button>().onClick.AddListener(() => { MenuManager.LoadLevelScene(); CurrentLevelManager.SetCurrentLevel(newButton.GetComponent<ButtonID>().GetID()); });
        }
    }
}

