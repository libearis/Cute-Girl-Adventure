    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Object References
    [SerializeField] private Animator attackAnimation;
    PlayerMovement playerMovement;

    float betweenAttackTime = 0.2f;
    public bool isAttacking;

    [SerializeField] Transform attackPosition;
    [SerializeField] LayerMask whatIsEnemies;
    [SerializeField] float attackRange;
    [SerializeField] Croc crocScript;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (isAttacking)
        {
            StartCoroutine(canAttackAgain());
        }

        if (Input.GetMouseButtonDown(0) && !isAttacking && !playerMovement.isJumping)
        {
            {
                attackAnimation.SetBool("isAttacking", true);
                isAttacking = true;
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    if (crocScript.vulnerability == true)
                    {
                        enemiesToDamage[i].GetComponent<Croc>().takeDamage(1);
                    }
                }
            }
        }
    }

    IEnumerator canAttackAgain()
    {

        yield return new WaitForSeconds(betweenAttackTime);

        attackAnimation.SetBool("isAttacking", false);
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
