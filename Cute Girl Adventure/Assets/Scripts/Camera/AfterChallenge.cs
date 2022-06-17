using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterChallenge : MonoBehaviour
{
    GirlMovement girlMovement;

    private void Awake()
    {
        girlMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<GirlMovement>();  
    }

    void Start()
    {
        StartCoroutine(animationEnded());
    }

    // Update is called once per frame
    IEnumerator animationEnded()
    {
        girlMovement.enabled = false;

        yield return new WaitForSeconds(5f);
        girlMovement.enabled = true;
        Destroy(this.gameObject);
    }
}
