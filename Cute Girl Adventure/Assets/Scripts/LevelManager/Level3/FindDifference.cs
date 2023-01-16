using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FindDifference : MonoBehaviour
{
    public Animator[] missedGuess;
    public GameObject victoryPanel, warningText, gameOverPanel, homeButton;
    public Animator sceneTransition;
    public TextMeshProUGUI timeCount, retryChanceText, differenceRemainingText;

    private int correctGuess, index;
    public string loadToScene;
    public bool[] isGuessed;
    public bool hardMode;
    private bool isStarting;

    public float timeRound = 30;
    public int timeDecreaseEffect, retryChance, numberGuess;
    public void Starting()
    {
        correctGuess = 0;
        isStarting = true;
        retryChance = PlayerPrefs.GetInt("retry", retryChance);
    }
    private void FixedUpdate()
    {
        differenceRemainingText.text = (numberGuess - correctGuess).ToString();
        if (timeDecreaseEffect != 0 && isStarting)
        {
            GameStart();
        }
        else if (timeDecreaseEffect == 0 && isStarting)
        {
            GameOver();
            isStarting = false;
        }
    }

    public void CountingGuess(int buttonIndex)
    {
        warningText.SetActive(false);
        if(isGuessed[buttonIndex])
        {
            warningText.SetActive(true); 
        }
        else
        {
            isGuessed[buttonIndex] = true;
            correctGuess++;
            if (correctGuess == numberGuess)
            {
                isStarting = false;
                StartCoroutine(BackToWorld());
            }
        }
    }

    IEnumerator BackToWorld()
    {
        victoryPanel.SetActive(true);

        yield return new WaitForSeconds(3f);
        sceneTransition.SetTrigger("End");

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(loadToScene);
    }

    public void missingGuess()
    {
        if (index == 4)
        {
            missedGuess[index].enabled = true;
            GameOver();
        }
        else if(hardMode)
        {
            missedGuess[index].enabled = true;
            index++;
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        retryChance--;
        PlayerPrefs.SetInt("retry", retryChance);
        retryChanceText.text = ("Retry Chances = " + retryChance);
        if (retryChance == 0)
        {
            homeButton.SetActive(true);
        }
    }
    private void GameStart()
    {
        timeRound -= Time.deltaTime;
        timeDecreaseEffect = Mathf.RoundToInt(timeRound);
        timeCount.text = timeDecreaseEffect.ToString();
    }
}
