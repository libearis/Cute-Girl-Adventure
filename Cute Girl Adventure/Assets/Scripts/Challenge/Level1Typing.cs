using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Level1Typing : MonoBehaviour
{
    public TextMeshProUGUI wordOutput = null;
    public TextMeshProUGUI timeCount;
    public TextMeshProUGUI retryChancesText;
    public int timeDecreaseEffect;
    public SpriteRenderer backGround;


    public GameObject victoryPanel;
    public GameObject restartButton;
    public GameObject retryChancesShow;
    public GameObject levelSelectionButton;

    public int retryChances;

    private float timeRound = 30;
    private bool gameIsFinished = false;
    private bool gameStarted = false;
    private bool isLosing = false;

    private string remainingWord = string.Empty;
    public List<string> currentWord;

    int rand;
    public int maxRand;

    private void Start()
    {
        retryChances = PlayerPrefs.GetInt("Health");
        maxRand = currentWord.Count - 1;
    }
    public void StartingTheGame()
    {
        SetCurrentWord();
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeDecreaseEffect != 0 && gameIsFinished == false && gameStarted)
        {
            CheckInput();
            GameFinish();
        }
        else if (gameIsFinished == false && timeDecreaseEffect == 0 && gameStarted && !isLosing)
        {
            isLosing = true;
            gameIsFinished = true;
            GameOver();
        }
    }

    private void SetCurrentWord()
    {
        rand = Random.Range(0, maxRand);
        SetRemainingWord(currentWord[rand]);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    private void CheckInput()
    {
        if(Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;

            if(keyPressed.Length == 1)
            {
                EnterLetter(keyPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            backGround.color = Color.green;
            RemoveLetter();

            if (IsWordComplete())
            {
                if (maxRand == 0)
                {
                    StartCoroutine(BackToWorld());
                }
                else
                {
                    maxRand--;
                    currentWord.RemoveAt(rand);
                    backGround.color = Color.cyan;
                    SetCurrentWord();
                }
            }
        }
        else
        {
            backGround.color = Color.red;
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

    private IEnumerator BackToWorld()
    {
        gameIsFinished = true;
        victoryPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level1");
    }

    private void GameFinish()
    {
        timeRound -= Time.deltaTime;
        timeDecreaseEffect = Mathf.RoundToInt(timeRound);
        timeCount.text = timeDecreaseEffect.ToString();
    }

    void GameOver()
    {
        if (isLosing)
        {
            backGround.color = Color.grey;
            wordOutput.text = "Game Over";
            retryChancesShow.SetActive(true);
            retryChancesText.text = "Retry Chances : " + retryChances.ToString();
            if (retryChances == 0)
            {
                retryChances = 2;
                PlayerPrefs.SetInt("Health", retryChances);
                levelSelectionButton.SetActive(true);
            }
            else
                restartButton.SetActive(true);
        }
    }
    public void RestartingLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isLosing = false;
        retryChances--;
        PlayerPrefs.SetInt("Health", retryChances);
        retryChancesShow.SetActive(false);
    }
    public void RefreshingPlayerPrefs()
    {
        SceneManager.LoadScene("AfterTyping");
    }
}
