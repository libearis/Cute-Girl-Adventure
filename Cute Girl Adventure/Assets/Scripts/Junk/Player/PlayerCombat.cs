using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] Croc crocScript;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerAttack playerAttack;

    private float knockbackX = 2f;
    private float knockbackY = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Croc")
        {
            if (crocScript.vulnerability == false)
            {
                StartCoroutine(takingDamageAnimation());
            }
        }
    }

    IEnumerator takingDamageAnimation()
    {
        rb.AddForce(new Vector2(-knockbackX, knockbackY), ForceMode2D.Impulse);
        playerHealth.takeDamage(1);
        anim.SetBool("isAttacked", true);
        playerAttack.enabled = false;
        playerMovement.enabled = false;

        yield return new WaitForSeconds(1f);
        playerAttack.enabled = true;
        playerMovement.enabled = true;
        anim.SetBool("isAttacked", false);
    }
}
