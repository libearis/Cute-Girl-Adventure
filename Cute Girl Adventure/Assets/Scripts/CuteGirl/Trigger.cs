using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Trigger : MonoBehaviour
{
    public static Trigger instance;

    public bool canTalktoFox,
                climbingRope,
                enteringDoor,
                enteringLockedDoor,
                enteringCloudy,
                finalAnswer,
                chestInteraction,
                finalQuestionSee,
                questionSee,
                challengeAccepted,
                challengeAccepted2,
                challengeAccepted3,
                answerCheck;

    private void Start()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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

            if (collision.tag == "ClimbRope")
            {
                climbingRope = true;
            }
            if (collision.tag == "Door")
            {
                enteringDoor = true;
            }
            if (collision.tag == "LockedDoor")
            {
                enteringLockedDoor = true;
            }
            if (collision.tag == "Key")
            {
                StartCoroutine(TriggerFunction.instance.GettingKey());
            }
        } // Collision Tag
        
        {
            if(collision.gameObject.name == "Standing White")
            {
                questionSee = true;
            }
            if (collision.gameObject.name == "Standing Blue")
            {
                finalQuestionSee = true;
            }
            if (collision.gameObject.name == "Standing Gold")
            {
                enteringCloudy = true;
            }
        } // Collision GameObject Name
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
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
            if (collision.tag == "Door")
            {
                enteringDoor = false;
            }
            if (collision.tag == "LockedDoor")
            {
                enteringLockedDoor = false;
            }
            if (collision.tag == "ClimbRope")
            {
                climbingRope = false;
            }
        } // Collision Tag
    }
}
