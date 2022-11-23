using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class LevelManager : MonoBehaviour 
{

    public static LevelManager instance;

    public Transform respawnPoint;

    public GameObject challengePanel, congratulationPanel;
    public GameObject playerPrefab;
    public GameObject questionDisplay;
    public GameObject answerScrollPanel;

    public int answerValue;

    Trigger girlTrigger;
    GirlMovement girlMovement;

    [SerializeField] Animator chestOpeningAnimation;

    public CinemachineVirtualCameraBase cam;

    [SerializeField] private string soundName;
    private void Awake()
    {
        AudioManager.instance.stopAllSound();
        AudioManager.instance.play(soundName);
        instance = this;
        girlTrigger = GameObject.FindWithTag("Player").GetComponent<Trigger>();
        girlMovement = GameObject.FindWithTag("Player").GetComponent<GirlMovement>();
    }
    
    public void Respawn()
    {
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;
    }

    private void FixedUpdate()
    {
        ChallengeCheck();
        QuestionDisplaying();
        if(Input.GetKeyDown(KeyCode.G))
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

    void AnsweringDoorQuestion()
    {
        if (girlTrigger.questionSee && answerValue == 30)
        {
            congratulationPanel.SetActive(true);
            girlMovement.enabled = false;
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
        SceneManager.LoadScene("LevelSelection1");
    }
}
