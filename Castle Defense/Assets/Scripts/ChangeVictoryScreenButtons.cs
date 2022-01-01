using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVictoryScreenButtons : MonoBehaviour
{
    public GameObject Next, Next2;

    void Awake()
    {
        if (CurrentLevelManager.CurrentLevel() == CurrentLevelManager.LevelsInCurrentScene())
        {
            Next.SetActive(false);

            Next2.SetActive(true);
        }
        else
        {
            Next.SetActive(true);

            Next2.SetActive(false);
        }
    }
    public void OnClick()
    {
        ErrorMessageManager.MakeErrorMessage("Scene Completed!");
    }
}
