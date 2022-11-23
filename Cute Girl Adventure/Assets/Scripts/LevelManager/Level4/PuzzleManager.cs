using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PuzzleManager : MonoBehaviour
{
    ChallengeManager4 challengeManager4;
    public string loadToScene;

    public GameObject[] puzzlePiece, puzzlePlace;
    public GameObject puzzlePanel, backToWorld, gameOver, retryButton;

    public Animator puzzleTemplate, puzzleEnd;
    public TextMeshProUGUI timeCount, roundText, retryChancesText;

    public int timeDecreaseEffect, round, scoreToWin, puzzleType, retryChances, screenValue, initialTime, score;

    private int index, randomSprite;
    public Vector2[] puzzlePos;

    public Image[] puzzleSprite, puzzleTransition;
    public Sprite[] sprite;
    public float x, y, timeRound, gameTime;

    bool exitingTransition;
    public bool winning, timeIsUp;
    // Start is called before the first frame update
    void Awake()
    {
        retryChances = PlayerPrefs.GetInt("Health", 2);
        challengeManager4 = GetComponent<ChallengeManager4>();
        randomSprite = Random.Range(0, (sprite.Length / puzzleType) - 1);
        randomSprite *= puzzleType;
        print(randomSprite);
        puzzlePos = new Vector2[puzzlePiece.Length];
        for(index = 0; index < puzzlePiece.Length; index++)
        {
            puzzleSprite[index].sprite = sprite[randomSprite];
            puzzleTransition[index].sprite = sprite[randomSprite];
            randomSprite++;
            x = Random.Range(50, 275);
            y = Random.Range(50, 180);
            puzzlePiece[index].transform.position = new Vector2(x , y);
            puzzlePos[index] = puzzlePiece[index].transform.position;
        }
    }

    private void Update()
    {
        roundText.text = "round " + round.ToString();
        if (challengeManager4.imageChallenge)
        {
            timeIsUp = false;
            gameTime += Time.deltaTime;
            if (gameTime >= 6f && !winning)
            {
                GameTimer();
            }

            if (score == scoreToWin)
            {
                winning = true;
                puzzleTemplate.SetTrigger("Winning");
                StartCoroutine(ReturningTheWorld());
            }
        }
        if (timeDecreaseEffect == 0)
        {
            if (round == 6)
            {
                retryChancesText.text = "Retry Chances : " + retryChances.ToString();
                gameOver.SetActive(true);
                if (retryChances == 0)
                {
                    StartCoroutine(GameOver());
                }
            }
            else
            {
                StartCoroutine(exitTransition());
                challengeManager4.puzzleTransition.SetActive(false);
            }
        }
    }
    public void RandomPos()
    {
        for (index = 0; index < puzzlePiece.Length; index++)
        {
            x = Random.Range(100, 440);
            y = Random.Range(100, 250);
            puzzlePiece[index].transform.position = new Vector2(x, y);
            puzzlePos[index] = puzzlePiece[index].transform.position;
        }
    }

    private void GameTimer()
    {
        timeDecreaseEffect = Mathf.RoundToInt(timeRound);
        timeCount.text = timeDecreaseEffect.ToString();
        timeRound -= Time.deltaTime;
        
    }

    IEnumerator exitTransition()
    {
        exitingTransition = true;
        puzzleEnd.SetBool("isExiting", true);
        challengeManager4.correctText.text = "Starting the Challenge";
        challengeManager4.bgImage.color = Color.white;
        yield return new WaitForSeconds(2.5f);

        puzzleEnd.SetBool("isExiting", false);
        puzzlePanel.SetActive(false);

        challengeManager4.imageChallenge = false;
        exitingTransition = false;
        timeRound = initialTime;
        gameTime = 1f;
        challengeManager4.correctText.text = "Click the puzzle when screen is Green";
    }

    IEnumerator ReturningTheWorld()
    {
        PlayerPrefs.DeleteAll();
        retryChances = 2;
        PlayerPrefs.SetInt("Health", retryChances);

        yield return new WaitForSeconds(2f);
        backToWorld.SetActive(true);

        yield return new WaitForSeconds(2f);
        GameManager.instance.ChangingScene(loadToScene);
    }

    private void OnApplicationQuit()
    {
        retryChances = 2;
        PlayerPrefs.SetInt("Health", retryChances);
    }
    public void RestartingLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        retryChances--;
        PlayerPrefs.SetInt("Health", retryChances);
    }
    IEnumerator GameOver()
    {
        retryButton.SetActive(false);

        yield return new WaitForSeconds(2f);
        GameManager.instance.SavingProgression(screenValue);
        GameManager.instance.CheckingProgression();

        PlayerPrefs.DeleteKey("Health");
    }
}
