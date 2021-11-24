using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessageManager : MonoBehaviour
{

    public static void MakeErrorMessage(string message, Vector2 pos)
    {
        GameObject newMessage = Instantiate(Resources.Load("Spawnables/ErrorMessage"), pos, Quaternion.identity) as GameObject;
        newMessage.GetComponent<ErrorMessage>().SetText(message);
    }
}
