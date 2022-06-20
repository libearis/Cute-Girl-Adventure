using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Level1Typing : MonoBehaviour
{
    public TextMeshProUGUI wordOutput = null;
    public TextMeshProUGUI timeCount;
    public int timeDecreaseEffect;
    public SpriteRenderer backGround;
    public GameObject victoryPanel;
    public GameObject restartButton;

    private float timeRound = 30;
    private bool gameIsFinished = false;

    private string remainingWord = string.Empty;
    public List<string> currentWord;

    int rand;
    public int maxRand = 19;
    void Start()
    {
        SetCurrentWord();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeDecreaseEffect != 0 && gameIsFinished == false)
        {
            CheckInput();
            GameFinish();
        }
        else if (gameIsFinished == false && timeDecreaseEffect == 0)
        {
            wordOutput.text = "Game Over";
            restartButton.SetActive(true);
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

    public void RestartingLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
