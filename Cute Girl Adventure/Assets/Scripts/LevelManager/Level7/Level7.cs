using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level7 : MonoBehaviour
{
    public static Level7 instance;

    [SerializeField] GameObject challengePanel, wheelPanel, warningKeyText;
    [SerializeField] GameObject[] colorMark;

    public bool goldShow, blueShow, whiteShow; 

    public GirlMovement girlMovement;
    public Trigger girlTrigger;
    void Start()
    {
        instance = this;
        girlMovement = GameObject.Find("Player").GetComponent<GirlMovement>();
        girlTrigger = GameObject.Find("Player").GetComponent<Trigger>();
    }

    private void Update()
    {
        if (girlTrigger.challengeAccepted)
        {
            print("Hi");
            challengePanel.SetActive(true);
        }
        else if (girlTrigger.questionSee)
        {
            this.gameObject.GetComponent<PieDetector>().enabled = true;
            wheelPanel.SetActive(true);
        }
        else
        {
            challengePanel.SetActive(false);
            wheelPanel.SetActive(false);
        }

        if(goldShow)
        {
            goldShow = false;
            colorMark[2].SetActive(true);
        }
        if(blueShow)
        {
            blueShow = false;
            colorMark[1].SetActive(true);
        }
        if(whiteShow)
        {
            whiteShow = false;
            colorMark[0].SetActive(true);
        }
    }

    private IEnumerator CantWalk()
    {
        girlMovement.enabled = false;

        yield return new WaitForSeconds(3.5f);
        girlMovement.enabled = true;
    }
    private IEnumerator WarningText()
    {
        warningKeyText.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        warningKeyText.SetActive(false);
    }
    public void CannotWalk()
    {
        girlMovement.enabled = false;
    }
}
