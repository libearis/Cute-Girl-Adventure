using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Level1Typing : MonoBehaviour
{
    public Animator sceneTransition;

    public TextMeshProUGUI wordOutput = null;
    public TextMeshProUGUI timeCount;
    public TextMeshProUGUI retryChancesText, wordLeft;
    public int timeDecreaseEffect;
    public float timeRound = 30;
    public SpriteRenderer backGround;


    public GameObject victoryPanel;
    public GameObject restartButton;
    public GameObject retryChancesShow;
    public GameObject levelSelectionButton;

    public int retryChances;

    
    private bool gameIsFinished = false;
    private bool gameStarted = false;
    private bool isLosing = false;

    private string remainingWord = string.Empty;
    public List<string> currentWord;
    public string loadToScene;

    int rand;
    public int maxRand;

    private void Start()
    {
        retryChances = PlayerPrefs.GetInt("Health", 2);
        maxRand = currentWord.Count;
    }
    public void StartingTheGame()
    {
        SetCurrentWord();
        gameStarted = true;
    }

    private void OnApplicationQuit()
    {
        retryChances = 2;
        PlayerPrefs.SetInt("Health", retryChances);
    }
    void Update()
    {
        if (timeDecreaseEffect != 0 && gameIsFinished == false && gameStarted)
        {
            CheckInput();
            GameFinish();
            wordLeft.text ="Word Left = " + currentWord.Count;
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
            string keyPressed = Input.inputString.ToLower();

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
                if (maxRand == 1)
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
        PlayerPrefs.DeleteAll();
        retryChances = 2;
        PlayerPrefs.SetInt("Health", retryChances);
        gameIsFinished = true;
        victoryPanel.SetActive(true);

        yield return new WaitForSeconds(3f);
        sceneTransition.SetTrigger("End");

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(loadToScene);
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
}
