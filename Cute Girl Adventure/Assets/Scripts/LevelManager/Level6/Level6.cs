using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level6 : MonoBehaviour
{
    public static Level6 instance;

    public GameObject challengePanel, warningKeyText;

    public string[] doorScene;

    public int dialogueTimer;

    GirlMovement girlMovement;
    Trigger girlTrigger;
    void Start()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        ChangingDoorScene();
        if (girlTrigger.challengeAccepted)
        {
            challengePanel.SetActive(true);
        }
        else challengePanel.SetActive(false);
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
}
