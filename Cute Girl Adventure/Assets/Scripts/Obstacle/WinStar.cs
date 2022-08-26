using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStar : MonoBehaviour
{
    GirlMovement girlMovement;
    Animator idleAnimation;
    public GameObject congratulationPanel;

    private void Start()
    {
        girlMovement = GameObject.FindWithTag("Player").GetComponent<GirlMovement>();
        idleAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            congratulationPanel.SetActive(true);
            idleAnimation.enabled = false;
            girlMovement.enabled = false;
        }
    }
}
