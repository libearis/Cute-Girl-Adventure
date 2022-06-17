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
    private float timeRound = 30;

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
        CheckInput();
        if (timeDecreaseEffect != 0)
        {
            GameFinish();
        }
        else
        {
            wordOutput.text = "Game Over";
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
            wordOutput.color = Color.white;
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
                    wordOutput.color = Color.white;
                    SetCurrentWord();
                }
            }
        }
        else wordOutput.color = Color.red;
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
        wordOutput.fontSize = 45;
        wordOutput.color = Color.white;
        wordOutput.text = "Level Completed, back to the world....";

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Level1");
    }

    private void GameFinish()
    {
        timeRound -= Time.deltaTime;
        timeDecreaseEffect = Mathf.RoundToInt(timeRound);
        timeCount.text = timeDecreaseEffect.ToString();
    }
}
