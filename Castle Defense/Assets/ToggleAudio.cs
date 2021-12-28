using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudio : MonoBehaviour
{
    public Sprite enabledImg, disabledImg;
    public bool isMusic;

    //1=true, 0=false
    public void ToggleMusic()
    {
        if (PlayerPrefs.GetInt("MusicEnabled", 1)==0)
        {
            PlayerPrefs.SetInt("MusicEnabled", 1);
            GetComponent<Image>().overrideSprite = enabledImg;
        }
        else
        {
            PlayerPrefs.SetInt("MusicEnabled", 0);

            GetComponent<Image>().overrideSprite = disabledImg;
        }
    }

    public void ToggleSFX()
    {
        if (PlayerPrefs.GetInt("SFXEnabled", 1) == 0)
        {
            PlayerPrefs.SetInt("SFXEnabled", 1);
            GetComponent<Image>().overrideSprite = enabledImg;
        }
        else
        {
            PlayerPrefs.SetInt("SFXEnabled", 0);
            GetComponent<Image>().overrideSprite = disabledImg;

        }
    }

    void Awake()
    {
        if (isMusic)
        {
            if (PlayerPrefs.GetInt("MusicEnabled", 1) == 1)
            {
                GetComponent<Image>().overrideSprite = enabledImg;
            }
            else
            {
                GetComponent<Image>().overrideSprite = disabledImg;
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("SFXEnabled", 1) == 1)
            {
                GetComponent<Image>().overrideSprite = enabledImg;
            }
            else
            {
                GetComponent<Image>().overrideSprite = disabledImg;
            }
        }

        //set music volumes here
    }
}
