using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneCardManager : MonoBehaviour
{
    public SceneCard card;
    public GameObject button;
    public TextMeshProUGUI sceneNumberTmp, progressTextTmp;

    void Start()
    {
        GetComponent<Image>().color = card.mainColor;
        button.GetComponent<Image>().color = card.buttonColor;
        sceneNumberTmp.text = "Scene: " + card.sceneNumber;

        if (PlayerPrefs.GetInt("CompletedScene", 0) >= card.sceneNumber)
        {
            card.completedLevel = card.totalLevels;
        }
        else if(PlayerPrefs.GetInt("CompletedScene", 0) == card.sceneNumber - 1)
        {
            card.completedLevel = PlayerPrefs.GetInt("CompletedLevel", 0);
        }
        else
        {
            card.completedLevel = 0;
        }

        progressTextTmp.text = card.completedLevel + "/" + card.totalLevels;

        SceneChangeManager man = GameObject.FindWithTag("SceneChangeManager").GetComponent<SceneChangeManager>();

        button.GetComponent<Button>().onClick.AddListener(() => { man.LoadLevelSelect(); man.ButtonClick(); });
    }

    public void SetCurrentLevelManagerVariables()
    {
        CurrentLevelManager.SetCurrentScene(card.sceneNumber);
        CurrentLevelManager.SetLevelsInCurrentScene(card.totalLevels);
    }
}

