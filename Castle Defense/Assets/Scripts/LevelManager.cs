using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public CoinManager gold;
    public int startGold;
    public GameObject VictoryMenu, DefeatMenu, castle, pointer;
    public Vector3 castlePos, cameraPos;
    public List<GameObject> pointers = new List<GameObject>();

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
            if(GameObject.FindGameObjectsWithTag("Ogre").Length == 0)
            {
                //if level is less than total levels in the schene, just update completed levels by +1.
                //else, scene +1 and level resets.
                if(CurrentLevelManager.CurrentScene() == PlayerPrefs.GetInt("CompletedScene"))
                {
                    if(CurrentLevelManager.CurrentLevel() < CurrentLevelManager.LevelsInCurrentScene())
                    {
                        PlayerPrefs.SetInt("CompletedLevel", CurrentLevelManager.CurrentLevel()+ 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt("CompletedScene", CurrentLevelManager.CurrentScene()+ 1);
                        PlayerPrefs.SetInt("CompletedLevel", 0);
                    }
                }
                OpenVictoryScreen();
            }
        }     
    }

    public IEnumerator LoadLoseScreen()
    {
        Camera.main.transform.position = new Vector3(castlePos.x, castlePos.y, cameraPos.z);
        Invoke("OpenDefeatScreen", 4.5f);

        while (Camera.main.orthographicSize >= 2)
        {
            Camera.main.orthographicSize -= Time.deltaTime * 1.5f;
            yield return null;
        }
        yield break;
    }
    public void StartCurrentLevel()
    {
        LevelSetup(CurrentLevelManager.CurrentLevel());
        CurrentLevelManager.SetCurrentLevel(CurrentLevelManager.CurrentLevel());
    }
    public void StartLevel(int level)
    {
        LevelSetup(level);
        CurrentLevelManager.SetCurrentLevel(level);
    }

    public void NextLevel()
    {
        LevelSetup(CurrentLevelManager.CurrentLevel() + 1);
        CurrentLevelManager.SetCurrentLevel(CurrentLevelManager.CurrentLevel() + 1);
    }

    public void RepeatLevel()
    {
        LevelSetup(CurrentLevelManager.CurrentLevel());
    }

    void LevelSetup(int levelNum)
    {
        Camera.main.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
        Camera.main.orthographicSize = 6;

        GameObject currentCastle = GameObject.FindWithTag("Castle");
        Destroy(currentCastle);
        Instantiate(castle, castlePos, Quaternion.identity);

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

        gold.SetGold(startGold);
        StartCoroutine(PassiveIncome(0.5f));
        StartCoroutine(CheckForWin(0.5f));

        Level level = Resources.Load<Level>("Levels/" + levelNum.ToString());

        foreach (Level.enemyPos enemy in level.ReturnEnemies())
        {
            var newEnemy = Instantiate(Resources.Load<GameObject>("Unit Prefabs/" + enemy.name) as GameObject, enemy.transform, Quaternion.identity);

            var newPointer = Instantiate(pointer, newEnemy.transform.position, Quaternion.identity);
            newPointer.GetComponent<EnemyPointer>().target = newEnemy;
            pointers.Add(newPointer);
        }
    }
    
    public void OpenVictoryScreen()
    {
        VictoryMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OpenDefeatScreen()
    {
        DefeatMenu.SetActive(true);
        Time.timeScale = 0f;
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
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level Select");
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
