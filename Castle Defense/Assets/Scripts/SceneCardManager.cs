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

        //if current scen and level are more than total levels, current scen is +1.

        if(PlayerPrefs.GetInt("CurrentScene", 1) == card.sceneNumber)
        {
            if (PlayerPrefs.GetInt("CurrentLevel", 1) >= card.totalLevels)
            {
                PlayerPrefs.SetInt("CurrentScene", PlayerPrefs.GetInt("CurrentScene", 1) + 1);
            }
            else
            {
                card.completedLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
            }
        }
        EditorUtility.SetDirty(card);
        if (PlayerPrefs.GetInt("CurrentScene", 1) > card.sceneNumber)
        {
            card.completedLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        }

        progressTextTmp.text = card.completedLevel + "/" + card.totalLevels;
    }

    public void SetCurrenLevelManagerVariables()
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

