using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static void LoadLevelScene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadSceneSelect()
    {
        SceneManager.LoadScene("Scene Select");
    }

    public void LoadLevelSelect( )
    {
        SceneManager.LoadScene("Level Select");
    }

    public void LoadHomeMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
