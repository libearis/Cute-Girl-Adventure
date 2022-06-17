using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Object References
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    private PlayerAttack playerAttack;

    // Data Variable
    private float moveSpeed = 3f;
    private float moveX;
    public float jumpForce = 5f;
    public bool isJumping = false;

    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (playerAttack.isAttacking == false)
        {
            Walking();
            Jumping();
        }
    }

    private void Walking()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveX * moveSpeed, 0, 0) * Time.deltaTime;
        if (moveX < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isRunning", true);
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void Jumping()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.0001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            isJumping = true;
        }
        else if (rb.velocity.y == 0)
        {
            animator.SetBool("isJumping", false);
            isJumping = false;
        }
    }
}
