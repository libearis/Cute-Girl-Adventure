using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Level3 : MonoBehaviour
{
    public GameObject challengePanel, challengePanel2, challengePanel3;
    public GameObject questionDisplay;
    public GameObject finalQuestionDisplay;
    public GameObject answerScroll;
    public GameObject congratulationPanel;
    public GameObject wrongAnswerPanel, haveNoAnswer;
    public GameObject removeCrate;

    public int answerValue;
    public int maximumJump;
    public string wrongAnswerChallenge;

    public Trigger girlTrigger;
    public GirlMovement girlMovement;

    [SerializeField] Animator chestOpeningAnimation;

    public CinemachineVirtualCameraBase cam;

    private void Awake()
    {
        girlTrigger = GameObject.FindWithTag("Player").GetComponent<Trigger>();
        girlMovement = GameObject.FindWithTag("Player").GetComponent<GirlMovement>();
        girlMovement.maxJump = maximumJump;
    }

    private void FixedUpdate()
    {
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
        girlMovement.maxJump = maximumJump;
        ChallengeCheck();
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
        if (girlTrigger.challengeAccepted2)
        {
            challengePanel2.SetActive(true);
        }
        else if (!girlTrigger.challengeAccepted2)
        {
            challengePanel2.SetActive(false);
        }
        if (girlTrigger.challengeAccepted3)
        {
            challengePanel3.SetActive(true);
        }
        else if (!girlTrigger.challengeAccepted3)
        {
            challengePanel3.SetActive(false);
            return;
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
        else if (girlTrigger.questionSee && answerValue == 0)
        {
            haveNoAnswer.SetActive((true));
        }

        else if (girlTrigger.questionSee && answerValue != 0 && answerValue != 4)
        {
            StartCoroutine(WrongAnswer());
        }
    }
    void AnsweringFinalQuestion()
    {
        if (girlTrigger.finalQuestionSee && answerValue == 2)
        {
            congratulationPanel.SetActive(true);
        }
        else if (girlTrigger.finalQuestionSee && answerValue == 0)
        {
            haveNoAnswer.SetActive((true));
        }

        else if (girlTrigger.finalQuestionSee && answerValue != 2 && answerValue != 0)
        {
            StartCoroutine(WrongAnswer());
        }
    }
    IEnumerator openingChest()
    {
        if (girlTrigger.chestInteraction)
        {
            chestOpeningAnimation.enabled = true;

            girlMovement.enabled = false;

            Chest.instance.DestroyCollider();
            yield return new WaitForSeconds(1f);
            answerScroll.SetActive(true);
        }
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
    IEnumerator WrongAnswer()
    {
        wrongAnswerPanel.SetActive(true);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(wrongAnswerChallenge);
    }
}
