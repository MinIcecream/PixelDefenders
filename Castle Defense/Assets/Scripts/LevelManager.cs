using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public CoinManager gold;
    public GameObject VictoryMenu, DefeatMenu, castle, pointer,healthBar;
    public Vector3 castlePos, cameraPos;
    public List<GameObject> pointers = new List<GameObject>();
    //public GameObject unitSelectionScreen;
    IEnumerator coroutine, incomeCoroutine;
    public PlayerControl player;
    
    void Awake()
    {
        if (PlayerPrefs.GetInt("MusicEnabled", 1) == 1)
        {
            AudioManager.Play("Theme");
        }
        StartCurrentLevel();
    }
    IEnumerator PassiveIncome(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            gold.AddGold(1);
        }
    }

    IEnumerator CheckForWin(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            //if you won:
            if(GameObject.FindGameObjectsWithTag("Ogre").Length == 0)
            {
                yield return new WaitForSeconds(1.5f);
                //if level is less than total levels in the schene, just update completed levels by +1.
                //else, scene +1 and level resets.

                //if ur past the completed scene:
                if(CurrentLevelManager.CurrentScene() > PlayerPrefs.GetInt("CompletedScene",0))
                {
                    if(CurrentLevelManager.CurrentLevel() < CurrentLevelManager.LevelsInCurrentScene())
                    {
                        if(CurrentLevelManager.CurrentLevel()>PlayerPrefs.GetInt("CompletedLevel", 0))
                        {
                            PlayerPrefs.SetInt("CompletedLevel", CurrentLevelManager.CurrentLevel());
                        }
                    }
                    else
                    {
                        PlayerPrefs.SetInt("CompletedScene", CurrentLevelManager.CurrentScene());
                        PlayerPrefs.SetInt("CompletedLevel", 0);
                    }
                }

                OpenVictoryScreen();
                AudioManager.Play("Fanfare");
                break;
            }
        }     
    }

    public IEnumerator LoadLoseScreen()
    {
        player.DisableSpawn();
        healthBar.SetActive(false);
        Camera.main.transform.position = new Vector3(castlePos.x, castlePos.y, cameraPos.z);
        Invoke("OpenDefeatScreen", 4.5f);

        while (Camera.main.orthographicSize >= 2)
        {
            Camera.main.orthographicSize -= Time.deltaTime * 1.5f;
            yield return null;
        }
        AudioManager.Play("Crash");
        yield break;
    }
    public void StartCurrentLevel()
    {
        LevelSetup(CurrentLevelManager.CurrentLevel());
        CurrentLevelManager.SetCurrentLevel(CurrentLevelManager.CurrentLevel());
    }

    public void NextLevelScreen()
    {
        CurrentLevelManager.SetCurrentLevel(CurrentLevelManager.CurrentLevel() + 1);
      //  unitSelectionScreen.SetActive(true);
        ClearLevel();
        StartCurrentLevel();
    }

    //Defeat 
    public void RepeatLevelScreen()
    {
        healthBar.SetActive(true);
        player.EnableSpawn();
        CurrentLevelManager.SetCurrentLevel(CurrentLevelManager.CurrentLevel());
       // unitSelectionScreen.SetActive(true);
        ClearLevel();
        StartCurrentLevel();
    }

    public void OpenVictoryScreen()
    {
        VictoryMenu.SetActive(true);
        Time.timeScale = 0f;
        if (PlayerPrefs.GetInt("MusicEnabled", 1) == 1)
        {
            AudioManager.SetVolume("Theme", 0.1f);
        }
    }
    public void OpenDefeatScreen()
    {
        DefeatMenu.SetActive(true);
        Time.timeScale = 0f;
        if (PlayerPrefs.GetInt("MusicEnabled", 1) == 1)
        {
            AudioManager.SetVolume("Theme", 0.1f);
        }
    }
    public void CloseVictoryScreen()
    {
        VictoryMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void CloseDefeatScreen()
    {
        DefeatMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void BackButton()
    {
        AudioManager.Stop("Theme");

        Time.timeScale = 1f;
        GameObject.FindWithTag("SceneChangeManager").GetComponent<SceneChangeManager>().LoadLevelSelect();
    }

    public void ClearLevel()
    {
        StopCoroutine(coroutine);
        StopCoroutine(incomeCoroutine);
        Camera.main.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
        Camera.main.orthographicSize = 6;
 
        foreach (GameObject orc in GameObject.FindGameObjectsWithTag("Ogre"))
        {
            Destroy(orc);
        }
        foreach (GameObject knight in GameObject.FindGameObjectsWithTag("Knight"))
        {
            Destroy(knight);
        }
        foreach (GameObject pointer in GameObject.FindGameObjectsWithTag("Pointer"))
        {
            pointers.Remove(pointer);
            Destroy(pointer);
        }
        foreach (GameObject particle in GameObject.FindGameObjectsWithTag("DeathParticles"))
        {
            Destroy(particle);
        }
        foreach (GameObject projectile in GameObject.FindGameObjectsWithTag("Projectile"))
        {
            Destroy(projectile);
        }
        foreach (GameObject pool in GameObject.FindGameObjectsWithTag("HealPool"))
        {
            Destroy(pool);
        }
    }


    //LEVEL SETUP
    void LevelSetup(int levelNum)
    {
        Time.timeScale = 1f;
        GameObject currentCastle = GameObject.FindWithTag("Castle");
        Destroy(currentCastle);
        Instantiate(castle, castlePos, Quaternion.identity);

        gold.SetGold((Resources.Load<Level>("Levels/"+CurrentLevelManager.CurrentScene()+"/"+levelNum.ToString())).gold);

        incomeCoroutine = PassiveIncome(1.5f);
        coroutine = CheckForWin(1f);

        StartCoroutine(coroutine);
        StartCoroutine(incomeCoroutine);

        Level level = Resources.Load<Level>("Levels/" + CurrentLevelManager.CurrentScene() + "/"+ levelNum.ToString());

        foreach (Level.enemyPos enemy in level.ReturnEnemies())
        {
            var newEnemy = Instantiate(Resources.Load<GameObject>("Unit Prefabs/Enemy Units/" + enemy.name) as GameObject, enemy.transform, Quaternion.identity);

            var newPointer = Instantiate(pointer, newEnemy.transform.position, Quaternion.identity);
            newPointer.GetComponent<EnemyPointer>().target = newEnemy;
            pointers.Add(newPointer);
        }
        if (PlayerPrefs.GetInt("MusicEnabled", 1) == 1)
        {
            AudioManager.SetVolume("Theme", 1f);
        }
 
    }

    void SpawnPointers()
    {
        foreach(GameObject orc in GameObject.FindGameObjectsWithTag("Ogre"))
        {
            var newPointer = Instantiate(pointer, orc.transform.position, Quaternion.identity);
            newPointer.GetComponent<EnemyPointer>().target = orc;
            pointers.Add(newPointer);
        }
    }
}
