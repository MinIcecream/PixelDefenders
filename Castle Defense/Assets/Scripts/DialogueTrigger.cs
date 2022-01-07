using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialogueObj;

    void Start()
    {
        dialogueObj.SetActive(true);

        if (PlayerPrefs.GetInt("CompletedTutorial", 0) == 0)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        } 
        
    }
}
