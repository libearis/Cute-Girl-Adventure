using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpForce = 8f;

    private float moveSpeed = 3f;
    private bool isJumping = false;

    public int maxJump = 1;
    private int jumpCount;

    void Update()
    {
        Walking();
        Jumping();
    }

    private void Walking()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveX * moveSpeed, 0, 0) * Time.deltaTime;
        if (moveX < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isWalking", true);
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void Jumping()
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
