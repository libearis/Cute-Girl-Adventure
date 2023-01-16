using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level6 : MonoBehaviour
{
    public static Level6 instance;

    [SerializeField] GameObject challengePanel, wheelPanel, warningKeyText;

    public string[] doorScene;

    public int dialogueTimer;

    public GirlMovement girlMovement;
    public Trigger girlTrigger;
    void Start()
    {
        instance = this;
        girlMovement = GameObject.Find("Player").GetComponent<GirlMovement>();
        girlTrigger = GameObject.Find("Player").GetComponent<Trigger>();
    }

    private void Update()
    {
        if (girlTrigger.challengeAccepted)
        {
            print("Hi");
            challengePanel.SetActive(true);
        }
        else if (girlTrigger.questionSee)
        {
            this.gameObject.GetComponent<PieDetector>().enabled = true;
            wheelPanel.SetActive(true);
        }
        else 
        {
            challengePanel.SetActive(false);
            wheelPanel.SetActive(false);
        }
        ChangingDoorScene();
    }

    public void ChangingDoorScene()
    {
        if (girlTrigger.enteringDoor)
        {
            GameManager.instance.ChangingScene(doorScene[0]);
            girlMovement.enabled = false;
        }
        else if (girlTrigger.enteringLockedDoor)
        {
            GameManager.instance.ChangingScene(doorScene[1]);
            girlMovement.enabled = false;
        }   
    }

    private IEnumerator CantWalk()
    {
        girlMovement.enabled = false;

        yield return new WaitForSeconds(3.5f);
        girlMovement.enabled = true;
    }
    private IEnumerator WarningText()
    {
        warningKeyText.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        warningKeyText.SetActive(false);
    }
    public void CannotWalk()
    {
        girlMovement.enabled = false;
    }
}
