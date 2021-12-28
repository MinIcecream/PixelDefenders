using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    bool mouseDown = false;

    public CoinManager gold;

    public RectTransform selectionBox;
    private Vector2 StartPos;

    GameObject character;

    public PlayerInventory inven;

    public LevelLoader loader;
    public Level level1;
    bool onUI = false;
    bool canSpawn = true;

    void Update()
    {
        if (inven.selectedChar!="")
        {
            character = Resources.Load<GameObject>("Unit Prefabs/Player Units/" + inven.selectedChar);
        }
        else
        {
            character = null;
        }

        if (EventSystem.current.currentSelectedGameObject != null)
        {
            onUI = true;
            StartCoroutine(LagOnUI());
        }

        if (Input.GetMouseButton(0) &&canSpawn&&!onUI)
        {
            if (mouseDown == false)
            {
                StartCoroutine(SpawnTimer());
                mouseDown = true;
            }   
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
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
                AudioManager.Play("Spawn");
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(character, mousePos, Quaternion.identity);
                gold.UseGold(cost);
            }
        }
        
    }
    IEnumerator LagOnUI()
    {
        yield return new WaitForSeconds(0.1f);
        onUI = false;
        yield break;
    }

    IEnumerator SpawnTimer()
    {
        if(character == null)
        {
            yield break;
        }
        SpawnCharacter(character);

        yield return new WaitForSeconds(0.25f);

        while (mouseDown)
        {
            SpawnCharacter(character);
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }

    public void DisableSpawn()
    {
        canSpawn = false;
    }
    public void EnableSpawn()
    {
        canSpawn = true;
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
