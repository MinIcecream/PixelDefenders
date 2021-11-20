using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //public static int currentLevel;
/*
    void Awake()
    {
        LoadLevel(1);
    }

    public void LoadLevel(int levelNum)
    {
        Level level = Resources.Load<Level>("Levels/" + levelNum.ToString());
        foreach (Level.enemyPos enemy in level.ReturnEnemies())
        {
            Instantiate(Resources.Load<GameObject>("Unit Prefabs/" + enemy.name) as GameObject, enemy.transform, Quaternion.identity);
        }
    }
*/
}
