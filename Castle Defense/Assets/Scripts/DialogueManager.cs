using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogueSentences = new Queue<string>();

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator anim;
    public Button button;

    public GameObject pointer, pointer2, pointer3;
    public int trigger1, trigger2, trigger3;

    int currentSentenceNumber=0;

    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;
        AudioManager.Stop("Theme");
        anim.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        dialogueSentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            dialogueSentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        button.enabled = true;
    }

    public void DisplayNextSentence()
    {
        if (dialogueSentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        pointer.SetActive(false);
        pointer2.SetActive(false);
        pointer3.SetActive(false);
 
        button.enabled = false;

        
        if (currentSentenceNumber == trigger1)
        {
            pointer.SetActive(true);
        }

        else if (currentSentenceNumber == trigger2)
        {
            pointer2.SetActive(true);
        }
        else if (currentSentenceNumber == trigger3)
        {
            pointer3.SetActive(true);
        }

        string sentence = dialogueSentences.Dequeue();

        StartCoroutine(TypeSentence(sentence));
        currentSentenceNumber++;
    }

    void EndDialogue()
    {
        Time.timeScale = 1;
        anim.SetBool("isOpen", false);
        PlayerPrefs.SetInt("CompletedTutorial", 1);

        AudioManager.Play("Theme");
    }
}
