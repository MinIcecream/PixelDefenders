using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public static void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void LoadSceneSelect()
    {
        SceneManager.LoadScene("Scene Select");
    }

    public void LoadLevelSelect()
    {
        AudioManager.Stop("Theme");
        SceneManager.LoadScene("Level Select");
    }

    public void LoadHomeMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ButtonClick()
    {
        AudioManager.Play("Click");
    }

    void Update()
    {  
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
