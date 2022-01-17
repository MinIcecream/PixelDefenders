using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessageManager : MonoBehaviour
{
    bool canSpawn=true;
    public static ErrorMessageManager instance;

    void Start()
    {
        instance = this;
    }

    public static void MakeErrorMessage(string message)
    {
        if (instance.canSpawn)
        {
            GameObject newMessage = Instantiate(Resources.Load("Spawnables/ErrorMessage"), new Vector2(0, 0), Quaternion.identity) as GameObject;

            newMessage.GetComponent<ErrorMessage>().SetText(message);
            newMessage.transform.SetParent(GameObject.FindWithTag("Canvas").transform);
            newMessage.GetComponent<RectTransform>().localPosition = new Vector2(0, 100);

            instance.canSpawn = false;
            instance.StartCoroutine(instance.SpawnTimer());
        }
    }
    IEnumerator SpawnTimer()
    {
        yield return new WaitForSecondsRealtime(1f);
        instance.canSpawn = true;
    }
}
