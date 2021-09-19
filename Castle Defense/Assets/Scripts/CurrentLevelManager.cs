using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevelManager : MonoBehaviour
{
    private static int currentLevel, currentScene, levelsInCurrentScene;

    public static int CurrentLevel()
    {
        return currentLevel;
    }

    public static int CurrentScene()
    {
        return currentScene;
    }
    public static int LevelsInCurrentScene()
    {
        return levelsInCurrentScene;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void SetCurrentScene(int scene)
    {
        currentScene = scene;
    }

    public static void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }

    public static void SetLevelsInCurrentScene(int sceneLevels)
    {
        levelsInCurrentScene = sceneLevels;
    }
}
