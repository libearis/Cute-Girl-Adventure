using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
public class Level1 : MonoBehaviour
{
    public GameObject challengePanel;
    public GameObject questionDisplay;
    public GameObject finalQuestionDisplay;
    public GameObject answerScrollDoor;
    public GameObject answerScrollFinal;
    public GameObject congratulationPanel;
    public GameObject removeCrate;

    public int answerValue;
    public bool doorDone = false;

    Trigger girlTrigger;
    GirlMovement girlMovement;

    [SerializeField] Animator chestOpeningAnimation;

    public CinemachineVirtualCameraBase cam;

    private void Awake()
    {
        girlTrigger = GameObject.FindWithTag("Player").GetComponent<Trigger>();
        girlMovement = GameObject.FindWithTag("Player").GetComponent<GirlMovement>();
    }

    private void FixedUpdate()
    {
        ChallengeCheck();
        QuestionDisplaying();
        FinalQuestionDisplaying();
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(openingChest());
            AnsweringDoorQuestion();
            AnsweringFinalQuestion();
        }

        if (girlTrigger == null)
        {
            girlTrigger = GameObject.FindWithTag("Player").GetComponent<Trigger>();
        }
        if (girlMovement == null)
        {
            girlMovement = GameObject.FindWithTag("Player").GetComponent<GirlMovement>();
        }
    }

    void ChallengeCheck()
    {
        if (girlTrigger.challengeAccepted)
        {
            challengePanel.SetActive(true);
        }
        else if (!girlTrigger.challengeAccepted)
        {
            challengePanel.SetActive(false);
        }
    }
    void QuestionDisplaying()
    {
        if (girlTrigger.questionSee)
        {
            questionDisplay.SetActive(true);
        }
        else if (!girlTrigger.questionSee)
        {
            questionDisplay.SetActive(false);
        }
    }

    void FinalQuestionDisplaying()
    {
        if (girlTrigger.finalQuestionSee)
        {
            finalQuestionDisplay.SetActive(true);
        }
        else if (!girlTrigger.finalQuestionSee)
        {
            finalQuestionDisplay.SetActive(false);
        }
    }

    void AnsweringDoorQuestion()
    {
        if (girlTrigger.questionSee && answerValue == 4)
        {
            removeCrate.SetActive(false);
        }
    }
    void AnsweringFinalQuestion()
    {
        if (girlTrigger.finalQuestionSee && answerValue == 6)
        {
            
        }
        else
        {
            Debug.Log("SALAHH!!!");
        }
    }
    IEnumerator openingChest()
    {
        if (girlTrigger.chestInteraction)
        {
            chestOpeningAnimation.enabled = true;

            girlMovement.enabled = false;
            if (!doorDone)
            {
                Chest.instance.DestroyCollider();
                yield return new WaitForSeconds(1f);
                answerScrollDoor.SetActive(true);
                doorDone = true;
            }

            else if (doorDone)
            {
                yield return new WaitForSeconds(1f);
                answerScrollFinal.SetActive(true);
            }
            
        }
    }
    public void ChallengeDone()
    {
        SceneManager.LoadScene("Tutorial Challenge Scene");
    }

    public void canWalkAgain()
    {
        StartCoroutine(canWalk());
    }

    IEnumerator canWalk()
    {
        yield return new WaitForSeconds(2.2f);

        girlMovement.enabled = true;
    }

    public void TrueAnswerAdd(int value)
    {
        answerValue = value;
    }

    public void LevelSelectionScreen(string screenName)
    {
        SceneManager.LoadScene(screenName);
    }
}
