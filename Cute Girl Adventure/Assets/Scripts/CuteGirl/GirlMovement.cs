using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    [SerializeField] Trigger girlTrigger;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpForce = 8f;

    private float moveSpeed = 3f;
    private bool isJumping, isHanging;

    public int maxJump = 1;
    private int jumpCount;

    void Update()
    {
        if(girlTrigger == null)
        {
            girlTrigger = GetComponent<Trigger>();
        }

        if(!isHanging)
        {
            Walking();
            Jumping();
        }

        ClimbingRope();
        HangingRope();
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
        if (jumpCount > 0 && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
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

    private void HangingRope()
    {
        if(girlTrigger.climbingRope && Input.GetKeyDown(KeyCode.E))
        {
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            animator.SetBool("isHanging", true);
            isHanging = true;
        }
        else if(!girlTrigger.climbingRope)
        {
            rb.isKinematic = false;
            animator.SetBool("isHanging", false);
            isHanging = false;
        }
    }
    
    private void ClimbingRope()
    {
        if(isHanging)
        {
            var moveX = Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(0, moveX * moveSpeed, 0) * Time.deltaTime;
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
