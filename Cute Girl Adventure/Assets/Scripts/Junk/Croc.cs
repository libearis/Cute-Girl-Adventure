using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Croc : MonoBehaviour
{
    public float currentHealth { get; private set; }
    private float maxHealth = 10;
    private float runningTime = 5;
    public float exhaustedTime;

    public bool vulnerability { get; private set; }

    Animator animator;

    [SerializeField] BossTrigger bossTrigger;
    [SerializeField] Image crocHealth;
    [SerializeField] Transform player;
    private bool isFlipped;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        exhaustedTime = runningTime;
        vulnerability = false;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (bossTrigger.bossFightBegin)
        {
            if (exhaustedTime <= 0)
            {
                animator.SetTrigger("isDizzy");
                animator.ResetTrigger("isRunning");
                vulnerability = true;

                StartCoroutine(whileInDizzy());
            }
            else
            {
                exhaustedTime -= Time.deltaTime;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(afterHittingPlayer());
            exhaustedTime = runningTime;
        }
    }

    IEnumerator whileInDizzy()
    {
        yield return new WaitForSecondsRealtime(2f);
        exhaustedTime = runningTime;
        animator.SetTrigger("isWakingUp");
        animator.ResetTrigger("isDizzy");

        yield return new WaitForSecondsRealtime(1f);
        animator.SetTrigger("isRunning");
        animator.ResetTrigger("isWakingUp");
        vulnerability = false;
    }

    IEnumerator afterHittingPlayer()
    {
        animator.SetBool("isWalking", true);

        yield return new WaitForSecondsRealtime(3f);
        animator.SetBool("isWalking", false);
        animator.SetTrigger("isRunning");
        exhaustedTime = runningTime;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        crocHealth.fillAmount = currentHealth / 10;
    }

    public void lookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x &&isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }

        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
    }
}
