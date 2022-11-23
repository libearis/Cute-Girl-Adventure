using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;

    public GameObject clickAnywhere, dialoguePanel;
    public TextMeshProUGUI textDisplay;
    public string[] sentences, backupSentences, scene;
    [HideInInspector] public int index;
    [SerializeField] float typingSpeed;
    public bool changingScene;

    private void Awake()
    {
        instance = this;
    }
    public IEnumerator TypingDialogue(float timer)
    {
        yield return new WaitForSeconds(timer);
        
        foreach(char letter in sentences[index])
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        index++;
        yield return new WaitForSeconds(1f);
        clickAnywhere.SetActive(true);
        print(index);
        print(sentences.Length);
    }

    public void changingDialogue()
    {
        textDisplay.text = "";
        sentences = new string[backupSentences.Length];
        foreach (string total in backupSentences)
        {
            sentences[index] = backupSentences[index];
            index++;
        }
        index = 0;
        backupSentences = null;
    }

    public void CheckingSentence()
    {
        if (index < sentences.Length)
        {
            textDisplay.text = "";
            clickAnywhere.SetActive(false);
            StartCoroutine(TypingDialogue(0.2f));
        }
        else
        {
            dialoguePanel.SetActive(false);
            changingScene = true;
            index = 0;
            GameObject.FindWithTag("Player").GetComponent<GirlMovement>().enabled = true;
            clickAnywhere.SetActive(false);
            if (backupSentences != null)
            {
                changingDialogue();
            }
        }
    }

    public void CheckingEnding()
    {
        if(changingScene)
        {
            GameManager.instance.ChangingScene(scene[0]);
        }
    }
}
