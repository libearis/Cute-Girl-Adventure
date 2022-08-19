using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Trigger : MonoBehaviour
{
    private bool canTalkToFox;
    public bool challengeAccepted = false;
    public bool challengeAccepted2 = false;
    public bool challengeAccepted3 = false;
    public bool answerCheck = false;
    public bool questionSee;
    public bool finalQuestionSee;
    public bool chestInteraction = false;
    public bool finalAnswer = false;
    public bool enteringCloudy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            Destroy(this.gameObject);
            RespawnManager.instance.Respawn();
        }
        if (collision.tag == "Challenge")
        {
            challengeAccepted = true;
        }
        if (collision.tag == "Challenge2")
        {
            challengeAccepted2 = true;
        }
        if (collision.tag == "Challenge3")
        {
            challengeAccepted3 = true;
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
        if (collision.tag == "Platforming")
        {
            enteringCloudy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Challenge")
        {
            challengeAccepted = false;
        }
        if (collision.tag == "Challenge2")
        {
            challengeAccepted2 = false;
        }
        if (collision.tag == "Challenge3")
        {
            challengeAccepted3 = false;
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
