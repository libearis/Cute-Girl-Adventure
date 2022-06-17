using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Trigger : MonoBehaviour
{
    public GameObject? challengePanel;
    private bool canTalkToFox;
    public bool challengeAccepted = false;
    public bool answerCheck = false;
    public bool questionSee;
    public bool finalQuestionSee;
    public bool chestInteraction = false;
    public bool finalAnswer = false;

    private void Awake()
    {
        challengePanel = GameObject.FindWithTag("Finish");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            Destroy(this.gameObject);
            LevelManager.instance.Respawn();
            Level1.instance.Respawn();
        }
        if (collision.tag == "Challenge")
        {
            challengeAccepted = true;
        }
        if (collision.tag == "Question")
        {
            questionSee = true;
        }

        if (collision.tag == "FinalQuestion")
        {
            finalQuestionSee = true;
        }

        if (collision.tag == "Answer")
        {
            answerCheck = true;
        }
        if (collision.tag == "Chest")
        {
            chestInteraction = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Challenge")
        {
            challengeAccepted = false;
        }
        if (collision.tag == "Question")
        {
            questionSee = false;
        }

        if (collision.tag == "FinalQuestion")
        {
            finalQuestionSee = false;
        }

        if (collision.tag == "Answer")
        {
            answerCheck = false;
        }
        if (collision.tag == "Chest")
        {
            chestInteraction = false;
        }
        if (collision.tag == "Finale")
        {
            finalAnswer = false;
        }
    }
}
