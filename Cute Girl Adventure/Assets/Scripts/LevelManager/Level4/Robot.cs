using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform playerPosition;
    [SerializeField] Transform firePosition;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float jumpForce = 8f, fireTimer, fireRate;

    private float moveSpeed = 3f;
    public float moveX;
    private bool isJumping = false, flipped;

    public int maxJump = 1;
    private int jumpCount;

    void Update()
    {
        Walking();
        Jumping();
        Shooting();
    }

    private void Walking()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveX * moveSpeed, 0, 0) * Time.deltaTime;
        if (moveX < 0)
        {
            animator.SetBool("isWalking", true);
        }
        else if (moveX > 0)
        {
            
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.A) && !flipped)
        {
            playerPosition.transform.Rotate(0f, 180f, 0f);
            flipped = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && flipped)
        {
            playerPosition.transform.Rotate(0f, 180f, 0f);
            flipped = false;
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

    private void Shooting()
    {
        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("isShooting", true);
            if (fireRate < 0)
            {
                Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
                fireRate = fireTimer;
            }
            else
            {
                fireRate -= Time.deltaTime;
            }
        }
        else animator.SetBool("isShooting", false);
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
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = maxJump;
            animator.SetBool("isJumping", false);
        }
    }
}
