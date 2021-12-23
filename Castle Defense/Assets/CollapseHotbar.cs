using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CollapseHotbar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite up, down;
    float y1 = -39.2f;
    float y2 = 42f;
    bool isDown = true;

    public PlayerInventory inv;
    public GameObject button;

    public void Collapse()
    {

        isDown = false;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, y2);
        button.GetComponent<Image>().overrideSprite = down;
    }
    public void Expand()
    {
        isDown = true;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, y1);
        button.GetComponent<Image>().overrideSprite = up;
    }

    public void ExpandOrCollapse()
    {
        if (isDown)
        {
            Collapse();
        }
        else
        {
            Expand();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            Color col = GetComponent<Image>().color;
            col.a = 1f;

            foreach (GameObject slot in inv.slots)
            {
                slot.GetComponent<Image>().color = col;
            }

            GetComponent<Image>().color = col;

            button.GetComponent<Image>().color = col;

        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {

        Debug.Log("DFJUIOS");
        Color col = GetComponent<Image>().color;
        col.a = 0.5f;

        foreach (GameObject slot in inv.slots)
        {
            slot.GetComponent<Image>().color = col;
        }

        GetComponent<Image>().color = col;

        button.GetComponent<Image>().color = col;

        
    }
}