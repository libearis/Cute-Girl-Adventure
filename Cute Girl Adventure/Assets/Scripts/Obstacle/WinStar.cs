using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStar : MonoBehaviour
{
    Animator idleAnimation;
    public GameObject congratulationPanel;

    private void Start()
    {
        idleAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            congratulationPanel.SetActive(true);
            idleAnimation.enabled = false;
        }
    }
}
