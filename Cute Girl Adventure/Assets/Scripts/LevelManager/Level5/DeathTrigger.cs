using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public static DeathTrigger instance;
    [SerializeField] GameObject gameOverPanel;

    Animator anim;
    [HideInInspector] public bool climbingRope, endRoad, isDead;
    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            gameOverPanel.SetActive(true);
            isDead = true;
            anim.SetBool("isDead", true);
            JumpingOnly.Destroy(GetComponent<JumpingOnly>());
        }
        if(collision.tag == "ClimbRope")
        {
            climbingRope = true;
        }
        if (collision.tag == "Key")
        {
            endRoad = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ClimbRope")
        {
            climbingRope = false;
        }
    }
}
