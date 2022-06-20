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
    public GameObject answerScrollPanel;
    public GameObject congratulationPanel;
    public GameObject removeCrate;

    public int answerValue;

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
    IEnumerator openingChest()
    {
        if (girlTrigger.chestInteraction)
        {
            chestOpeningAnimation.enabled = true;

            girlMovement.enabled = false;

            yield return new WaitForSeconds(1f);

            answerScrollPanel.SetActive(true);
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

    public void TrueAnswerAdd()
    {
        answerValue = 30;
    }

    public void LevelSelectionScreen()
    {
        SceneManager.LoadScene("Challenge1");
    }
}
