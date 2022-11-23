using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChallengeManager4 : MonoBehaviour
{
    PuzzleManager puzzleManager;
    public Animator[] missedGuess;

    public TextMeshProUGUI correctText;
    public Image bgImage;
    public float timerRate;
    private int randomNumber, missClick;
    public bool imageChallenge;

    public GameObject puzzlePanel, puzzleTransition, gameOverPanel;

    public Color[] colorList;
    void Start()
    {
        puzzleManager = GetComponent<PuzzleManager>();
    }

    void FixedUpdate()
    {
        if (timerRate <= 0 && !imageChallenge)
        {
            randomNumber = Random.Range(0, colorList.Length);
            bgImage.color = colorList[randomNumber];
            
            timerRate = 0.5f;
        }

        if (!imageChallenge)
        { 
            timerRate -= Time.deltaTime;
        } 
        if(missClick == 5)
        {
            gameOverPanel.SetActive(true);
        }
    }

    IEnumerator PuzzleTransition()
    {
        correctText.text = "Correct, loading puzzle screen";
        puzzleTransition.SetActive(true);

        yield return new WaitForSeconds(3.5f);
        puzzlePanel.SetActive(true);
    }

    public void Validate()
    {
        if(randomNumber == 3)
        {
            StartCoroutine(PuzzleTransition());
            puzzleManager.round++;
            timerRate = 1f;
            imageChallenge = true;
        }
        else
        {
            missedGuess[missClick].enabled = true;
            missClick++;
        }
    }
}
