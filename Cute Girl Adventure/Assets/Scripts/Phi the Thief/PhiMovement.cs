using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhiMovement : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public Transform scrollPosition, phiHandPosition;

    private int moveSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        Walking();
        scrollPosition.position = phiHandPosition.position;
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
}
