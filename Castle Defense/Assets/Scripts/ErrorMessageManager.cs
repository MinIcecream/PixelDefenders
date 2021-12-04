using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessageManager : MonoBehaviour
{
    public static void MakeErrorMessage(string message)
    {
        GameObject newMessage = Instantiate(Resources.Load("Spawnables/ErrorMessage"), new Vector2(0,0), Quaternion.identity) as GameObject;
        newMessage.GetComponent<ErrorMessage>().SetText(message);
        newMessage.transform.SetParent(GameObject.FindWithTag("Canvas").transform);
        newMessage.GetComponent<RectTransform>().localPosition = new Vector2(0, 100);
    }
}
