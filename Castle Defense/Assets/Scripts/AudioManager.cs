using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.isLoop;
        }
    }

    public static void Play(string name)
    {
        Sound s = Array.Find(instance.sounds, sound => sound.name == name);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }
    public static void Stop(string name)
    {
        Sound s = Array.Find(instance.sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }
    public static void SetVolume(string name, float vol)
    {
        Sound s = Array.Find(instance.sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.volume = vol;
        s.volume = vol;
    }

    public static void UpdateAudio()
    {
        foreach(Sound s in instance.sounds)
        {  
            if(s.isMusic == true)
            {
                if (PlayerPrefs.GetInt("MusicEnabled", 1) == 0)
                {
                     s.volume = 0;
                }
                else
                {
                    s.volume = 1;
                }
            }

            else
            {
                if (PlayerPrefs.GetInt("SFXEnabled", 1) == 0)
                {
                    s.volume = 0;
                }
                else
                {
                    s.volume = 1;
                }
            }
        }
        foreach (Sound s in instance.sounds)
        {
            s.source.volume = s.volume;
        }
    }
}
