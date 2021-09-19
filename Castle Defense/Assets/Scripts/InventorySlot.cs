using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    public GameObject image;
    public PlayerInventory invenMan;
    [Range(1,6)]
    public int slotNum;

    public void SetImage(string character)
    {
        image.SetActive(true);
        image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Units/" + character);
    }

    public void Clicked()
    {
        invenMan.SetActiveChar(slotNum);
    }
}
