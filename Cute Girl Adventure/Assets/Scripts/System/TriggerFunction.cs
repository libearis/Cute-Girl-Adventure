using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFunction : MonoBehaviour
{
    public static TriggerFunction instance;

    public GameObject keyModel, keyPanel, challengePanel, warningKeyText;

    public string doorScene;
    public bool startCantWalk, canEnterLocked, startWithDialogue;

    public int dialogueTimer;

    public GirlMovement girlMovement;
    public Trigger girlTrigger;
    void Start()
    {
        instance = this;
        if(startCantWalk)
        {
            StartCoroutine(CantWalk());
        }
        if(startWithDialogue)
        {
            StartCoroutine(DialogueSystem.instance.TypingDialogue(dialogueTimer));
        }
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
    public IEnumerator GettingKey()
    {
        keyPanel.SetActive(true);
        Destroy(keyModel.gameObject);
        girlMovement.enabled = false;

        yield return new WaitForSeconds(3.5f);
        girlMovement.enabled = true;
    }

    public void ChangingDoorScene()
    {
        if (girlTrigger.enteringDoor)
        {
            GameManager.instance.ChangingScene(doorScene);
            girlMovement.enabled = false;
        }
        else if (girlTrigger.enteringLockedDoor && Input.GetKeyDown(KeyCode.G) && canEnterLocked)
        {
            GameManager.instance.ChangingScene(doorScene);
            girlMovement.enabled = false;
        }
        else if (girlTrigger.enteringLockedDoor && Input.GetKeyDown(KeyCode.G) && !canEnterLocked)
        {
            StartCoroutine(WarningText());
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
