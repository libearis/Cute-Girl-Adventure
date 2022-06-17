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
        if (Mathf.Abs(rb.velocity.y) < 0.0001f && Input.GetKeyDown(KeyCode.Space))
        {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                animator.SetBool("isJumping", true);
                isJumping = true;
        }
        else if (Mathf.Abs(rb.velocity.y) > 0.01f)
        {
            animator.SetBool("isJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }
}
