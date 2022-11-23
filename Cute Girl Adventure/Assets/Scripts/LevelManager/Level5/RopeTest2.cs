using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTest2 : MonoBehaviour
{
    Transform ropeHoldPosition;
    [SerializeField] Transform playerPosition;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator playerAnim;

    bool holdingRope, jumpingOut;
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void Update()
    {
        if(holdingRope)
        {
            playerPosition.position = ropeHoldPosition.position;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.velocity = Vector2.up * 8;
                playerAnim.SetBool("isJumping", true);
                playerAnim.SetBool("isHanging", false);
                holdingRope = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            holdingRope = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !holdingRope)
        {
            holdingRope = true;
        }
    }
}
