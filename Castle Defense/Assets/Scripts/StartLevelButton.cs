using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelButton : MonoBehaviour
{
    public PlayerInventory inventory;
    public LevelManager levelManager;
    public GameObject selectCanvas;

    public void OnClick()
    {
        bool shouldContinue = false;

        foreach(string nonce in inventory.chars)
        {
            if(nonce != "")
            {
                shouldContinue = true;
            }
        }

        if (shouldContinue == false)
        {
            ErrorMessageManager.MakeErrorMessage("Select at least one unit!");
        }

        else
        {
            levelManager.StartCurrentLevel();
            selectCanvas.SetActive(false);
        }
    }
}
