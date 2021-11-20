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
    public GameObject unitSelectionScreen;
    IEnumerator coroutine;
    public GameObject parent;

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
                break;
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

    public void NextLevelScreen()
    {
        CurrentLevelManager.SetCurrentLevel(CurrentLevelManager.CurrentLevel() + 1);
        unitSelectionScreen.SetActive(true);
        ClearLevel();
    }
    public void RepeatLevelScreen()
    {
        CurrentLevelManager.SetCurrentLevel(CurrentLevelManager.CurrentLevel());
        unitSelectionScreen.SetActive(true);
        ClearLevel();
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
        parent.SetActive(true);
        parent.GetComponent<CharacterIconParent>().ResetSlots();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level Select");
    }

    public void ClearLevel()
    {
        StopCoroutine(coroutine);

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
    }


    //LEVEL SETUP
    void LevelSetup(int levelNum)
    {
        GameObject currentCastle = GameObject.FindWithTag("Castle");
        Destroy(currentCastle);
        Instantiate(castle, castlePos, Quaternion.identity);

        gold.SetGold(startGold);
        StartCoroutine(PassiveIncome(0.5f));
        coroutine = CheckForWin(0.5f);
        StartCoroutine(coroutine);

        Level level = Resources.Load<Level>("Levels/" + CurrentLevelManager.CurrentScene() + "/"+ levelNum.ToString());

        foreach (Level.enemyPos enemy in level.ReturnEnemies())
        {
            var newEnemy = Instantiate(Resources.Load<GameObject>("Unit Prefabs/Enemy Units/" + enemy.name) as GameObject, enemy.transform, Quaternion.identity);

            var newPointer = Instantiate(pointer, newEnemy.transform.position, Quaternion.identity);
            newPointer.GetComponent<EnemyPointer>().target = newEnemy;
            pointers.Add(newPointer);
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
