using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Level5 : MonoBehaviour
{
    public static Level5 instance;
    GroundSliding groundSliding;
    JumpingOnly jumpingOnly;

    [SerializeField] GameObject instructionPanel, ChaseBeginPanel;
    [SerializeField] Button clickAnywhere;
    [SerializeField] bool phiAlreadyLeaving, startWithDialogue;
    [SerializeField] float dialogueTimer;
    [SerializeField] PlayableDirector afterDialogue, phiLeave;
    void Start()
    {
        jumpingOnly = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpingOnly>();
        groundSliding = GetComponent<GroundSliding>();
        instance = this;
        if(startWithDialogue)
        {
            StartCoroutine(DialogueSystem.instance.TypingDialogue(dialogueTimer));
        }
    }

    void Update()
    {
        if(!phiAlreadyLeaving && DialogueSystem.instance.changingScene)
        {
            phiAlreadyLeaving = true;
            afterDialogue.enabled = true;
            Invoke("InstructionShow", 2f);
        }
        if(DeathTrigger.instance.endRoad && DialogueSystem.instance.index == 3)
        {
            clickAnywhere.onClick.AddListener(ActivatePhiLeaveCutscene);
        }
    }

    public void GameStartingButton()
    {
        StartCoroutine(GameStarting());
    }

    public void PlayingSound(string name)
    {
        AudioManager.instance.play(name);
    }

    void InstructionShow()
    {
        instructionPanel.SetActive(true);
    }

    void ActivatePhiLeaveCutscene()
    {
        phiLeave.enabled = true;
    }  

    void EnablingMovement()
    {
        jumpingOnly.enabled = true;
    }
    IEnumerator GameStarting()
    {
        yield return new WaitForSeconds(2.5f);
        ChaseBeginPanel.SetActive(false);
        groundSliding.gameStarted = true;
    }
}
