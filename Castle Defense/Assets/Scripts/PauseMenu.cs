using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        if (PlayerPrefs.GetInt("MusicEnabled", 1) == 1)
        {
            AudioManager.SetVolume("Theme", 1f);
        }
    }

    public void ReturnToSelect()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        if (PlayerPrefs.GetInt("MusicEnabled", 1) == 1)
        {
            AudioManager.Stop("Theme");
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

        if (PlayerPrefs.GetInt("MusicEnabled", 1) == 1)
        {
            AudioManager.SetVolume("Theme", 0.1f);
        }
    }

}
