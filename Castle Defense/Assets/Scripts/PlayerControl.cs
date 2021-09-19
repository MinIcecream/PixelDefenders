using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    float spawnTime = 0.1f;

    bool canSpawn = true;

    // bool spawn = true;

    public CoinManager gold;

    public RectTransform selectionBox;
    private Vector2 StartPos;

    GameObject character;

    public PlayerInventory inven;

    public LevelLoader loader;
    public Level level1;

    void Update()
    {
        if (inven.selectedChar)
        {
            character = inven.selectedChar;
        }
        else
        {
            character = null;
        }

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (canSpawn && character)
            {
                SpawnCharacter(character);
                canSpawn = false;
            }
        }
        if (spawnTime <= 0)
        {
            canSpawn = true;
            spawnTime = 0.1f;
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
 
        /*
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartPos = Input.mousePosition;
                UpdateSelectionBox(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                UpdateSelectionBox(Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                ReleaseSelectionBox();
            }
        }*/

    }
    void SpawnCharacter(GameObject character)
    {
        if(character.tag == "Ogre")
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(character, mousePos, Quaternion.identity);
        }
        else
        {
            int cost = character.GetComponent<KnightManager>().knight.cost;
            if (gold.CheckGold() >= cost)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(character, mousePos, Quaternion.identity);
                gold.UseGold(cost);
            }
        }
        
    }
    #region selection
    void UpdateSelectionBox (Vector2 currentMousePos)
    {
        if (!selectionBox.gameObject.activeInHierarchy)
        {
            selectionBox.gameObject.SetActive(true);
        }

        float width = currentMousePos.x - StartPos.x;
        float height = currentMousePos.y - StartPos.y;

        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        selectionBox.anchoredPosition = StartPos + new Vector2(width / 2, height / 2);
    }

    void ReleaseSelectionBox()
    {
        selectionBox.gameObject.SetActive(false);

        Vector2 min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
        Vector2 max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);

        List<GameObject> units = new List<GameObject>();
        List<GameObject> selectedUnits = new List<GameObject>();

        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if(go.tag == "Knight")
            {
                units.Add(go);
            }
        }
        foreach(GameObject unit in units)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(unit.transform.position);

            if (screenPos.x > min.x && screenPos.x < max.x && screenPos.y > min.y && screenPos.y < max.y)
            {
                unit.transform.GetChild(0).GetComponent<Highlight>().OutlineObject();
            }
        }
        Debug.Log(selectedUnits.Count);
    }
    #endregion
}
