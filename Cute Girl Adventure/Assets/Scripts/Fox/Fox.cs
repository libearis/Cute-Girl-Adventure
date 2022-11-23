using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public static Fox instance;
    SpriteRenderer cowboy;


    public GameObject bubbleChat;
    public GameObject foxDialogPanel;
    [SerializeField] DialogueSystem dialogueSystem;
    GirlMovement girlMovement;
    private bool canTalkToFox = false;

    private void Awake()
    {
        instance = this;
        girlMovement = GameObject.FindWithTag("Player").GetComponent<GirlMovement>();
    }

    private void Update()
    {
        if(canTalkToFox && Input.GetKeyDown(KeyCode.G))
        {
            TalkingToFox();
        }
        if(girlMovement == null)
        {
            girlMovement = GameObject.FindWithTag("Player").GetComponent<GirlMovement>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bubbleChat.SetActive(true);
            canTalkToFox = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bubbleChat.SetActive(false);
            canTalkToFox = false;
        }
    }

    void TalkingToFox()
    {
        canTalkToFox = false;
        foxDialogPanel.SetActive(true);
        StartCoroutine(dialogueSystem.TypingDialogue(1f));
        girlMovement.enabled = false;
    }
    public void OnClickClose()
    {
        canTalkToFox = true;
        girlMovement.enabled = true;
        dialogueSystem.textDisplay.text = "";
        dialogueSystem.clickAnywhere.SetActive(false);
        foxDialogPanel.SetActive(false);
    }
}
