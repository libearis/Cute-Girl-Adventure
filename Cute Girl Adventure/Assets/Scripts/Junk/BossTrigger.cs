using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private Animator deadEndClosing;
    [SerializeField] private Animator playerAnimation;
    [SerializeField] private Animator bossFight;
    [SerializeField] private Animator camAnimation;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAttack playerAttack; 

    [SerializeField] private GameObject bossCam;

    private PlayableDirector playableDirector;

    private bool doneEnter;
    [HideInInspector] public bool bossFightBegin = false;
    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !doneEnter)
        {
            doneEnter = true;
            bossCam.SetActive(true);
            deadEndClosing.SetBool("enteringBoss", true);
            StartCoroutine(playingTimeline()); 
            StartCoroutine(disableMovement());
        }   
    }

    IEnumerator disableMovement()
    {
        playerAnimation.SetBool("isRunning", false);
        playerAnimation.SetBool("isAttacking", false);
        playerAnimation.SetBool("isJumping", false);
        playerMovement.enabled = false;
        playerAttack.enabled = false;

        yield return new WaitForSeconds(9f);

        playerMovement.enabled = true;
        playerAttack.enabled = true;
        bossFight.SetTrigger("isRunning");
        bossFightBegin = true;
    }

    IEnumerator playingTimeline()
    {
        yield return new WaitForSeconds(2f);
        playableDirector.Play();
        camAnimation.SetBool("enteringBoss", true);
    }
}
