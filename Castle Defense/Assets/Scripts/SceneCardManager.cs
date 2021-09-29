using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

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

        if (PlayerPrefs.GetInt("CompletedScene", 1) >= card.sceneNumber)
        {
            card.completedLevel = card.totalLevels;
        }
        else if(PlayerPrefs.GetInt("CompletedScene", 1) == card.sceneNumber - 1)
        {
            card.completedLevel = PlayerPrefs.GetInt("CompletedLevel",1);
        }
        else
        {
            card.completedLevel = 0;
        }

        progressTextTmp.text = card.completedLevel + "/" + card.totalLevels;
    }

    public void SetCurrentLevelManagerVariables()
    {
        CurrentLevelManager.SetCurrentScene(card.sceneNumber);
        CurrentLevelManager.SetLevelsInCurrentScene(card.totalLevels);
    }
#if Unity_Editor
    public void SaveLevel()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Ogre");

        if (level != null)
        {
            EditorUtility.SetDirty(level);
            foreach (GameObject obj in objs)
            {
                level.AddEnemy(obj.GetComponent<OgreManager>().ogre.name, obj.transform.position);
            }
        }
    }
#endif
}

