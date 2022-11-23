using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingOnly : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;

    [SerializeField] float jumpForce = 12f;

    private bool isHanging;
    [HideInInspector] public int jumpCount = 1, maxJump = 1;
    
    void Update()
    {
        if (!isHanging)
        {
            Jumping();
        }
    }
    public void Jumping()
    {
        if (jumpCount > 0 && Input.GetKeyDown(KeyCode.Space) && rb.velocity.y > -0.01f)
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
            jumpCount -= 1;
        }
        else if (Mathf.Abs(rb.velocity.y) > 0.01f)
        {
            animator.SetBool("isJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && rb.velocity.y == 0)
        {
            jumpCount = maxJump;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && rb.velocity.y == 0)
        {
            jumpCount = maxJump;
            animator.SetBool("isJumping", false);
        }
    }

    
}
