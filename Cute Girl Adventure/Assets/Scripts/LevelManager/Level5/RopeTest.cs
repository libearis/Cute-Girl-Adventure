using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTest : MonoBehaviour
{
    [SerializeField] Transform[] ropeHoldingPosition;
    Animator anim;
    Rigidbody2D rb;

    int index;
    bool holdingRope;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (holdingRope)
        {
            transform.position = ropeHoldingPosition[index].position;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * 8;
                anim.SetBool("isJumping", true);
                anim.SetBool("isHanging", false);
                holdingRope = false;
                index++;
            }
        }
        if (DeathTrigger.instance.climbingRope && Input.GetKeyDown(KeyCode.E) && !holdingRope)
        {
            holdingRope = true;
            anim.SetBool("isHanging", true);
        }
    }
}
