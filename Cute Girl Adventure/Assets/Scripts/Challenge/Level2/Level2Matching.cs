using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Level2Matching : MonoBehaviour
{
    public Animator sceneTransition;
    public TextMeshProUGUI timeCount, retryChanceText;

    public Sprite defaultSprite;
    public Sprite[] puzzleSprite;
    public List<Button> btn = new List<Button>();
    public List<Animator> buttonSpin = new List<Animator>();
    public GameObject victoryPanel, gameOver, boxPanel, homeButton;
    public GameObject warningText, disguisedPanel, funnyWord;
        
    public bool firstGuess, secondGuess;

    private int countGuess, countCorrectGuess, totalGuess = 0;
    private int firstGuessIndex, secondGuessIndex;
    private int index;

    public float timeRound = 30;
    public int timeDecreaseEffect, retryChance;

    private string firstGuessPuzzle, secondGuessPuzzle;
    public string loadToScene;

    GameObject[] puzzleObject;
    private bool gameStarted, notLosing;

    // Start is called before the first frame update
    public void Starting()
    {
        funnyWord.SetActive(true);
        retryChance = PlayerPrefs.GetInt("retry", retryChance);
        firstGuess = secondGuess = false;
        StartCoroutine(showingBox());
    }

    private void FixedUpdate()
    {
        if (timeDecreaseEffect != 0 && gameStarted && notLosing)
        {
            GameStart();
        }
        else if(timeDecreaseEffect == 0 && gameStarted && notLosing)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        retryChance--;
        PlayerPrefs.SetInt("retry", retryChance);
        gameOver.SetActive(true);
        notLosing = false;
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

    void AddListener()
    {
        foreach (Button btns in btn)
        {
            btns.onClick.AddListener(() => OnClickEvent());
        }
    }

    public void OnClickEvent()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        warningText.SetActive(false);
        if (!firstGuess && notLosing)
        {
            firstGuess = true;

            firstGuessIndex = int.Parse(name);
            firstGuessPuzzle = puzzleSprite[firstGuessIndex].name;
            StartCoroutine(spinningBox());
        }

        else if (firstGuess && notLosing)
        {
            secondGuess = true;

            secondGuessIndex = int.Parse(name);
            if(secondGuessIndex == firstGuessIndex)
            {
                warningText.SetActive(true);
            }    
            else
            {
                disguisedPanel.SetActive(true);
                StartCoroutine(spinningBox2());

                secondGuessPuzzle = puzzleSprite[secondGuessIndex].name;
                /*for (int i = 0; i < puzzleSprite.Length; i++)
                {
                    btn[i].interactable = false;
                }
                btn[firstGuessIndex].interactable = true;
                btn[secondGuessIndex].interactable = true;*/
                StartCoroutine(CheckingPuzzleMatch());
            }
        }
    }

    IEnumerator spinningBox()
    {
        buttonSpin[firstGuessIndex].SetTrigger("isClicking");
        yield return new WaitForSeconds(.5f);
        btn[firstGuessIndex].image.sprite = puzzleSprite[firstGuessIndex];
    }
    IEnumerator spinningBox2()
    {
        buttonSpin[secondGuessIndex].SetTrigger("isClicking");
        yield return new WaitForSeconds(.5f);
        btn[secondGuessIndex].image.sprite = puzzleSprite[secondGuessIndex];
    }
    IEnumerator CheckingPuzzleMatch()
    {
        yield return new WaitForSeconds(1.5f);
        disguisedPanel.SetActive(false);
        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            for (int i = 0; i < puzzleSprite.Length; i++)
            {
                btn[i].interactable = true;
            }
            btn[firstGuessIndex].interactable = false;
            btn[secondGuessIndex].interactable = false;

            btn[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btn[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            countCorrectGuess++;
            if (countCorrectGuess == puzzleSprite.Length / 2)
            {
                victoryPanel.SetActive(true);
                StartCoroutine(backToWorld(loadToScene));
            }
        }
        else
        {
            btn[firstGuessIndex].image.sprite = defaultSprite;
            btn[secondGuessIndex].image.sprite = defaultSprite;
            for (int i = 0; i < puzzleSprite.Length; i++)
            {
                btn[i].interactable = true;
            }
        }
        firstGuess = secondGuess = false;
    }

    void Shuffling()
    {
        for(int i = 0; i < puzzleObject.Length; i++)
        {
            Sprite temp = puzzleSprite[i];
            int randomIndex = Random.Range(i, PuzzleBox.instance.maxBox);
            puzzleSprite[i] = puzzleSprite[randomIndex];
            puzzleSprite[randomIndex] = temp;
        }
    }
    private IEnumerator backToWorld(string screenName)
    {
        gameStarted = false;
        yield return new WaitForSeconds(2f);
        sceneTransition.SetTrigger("End");

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(screenName);
    }
    
    IEnumerator showingBox()
    {
        yield return new WaitForSeconds(2f);

        gameStarted = notLosing = true;
        boxPanel.SetActive(true);
        puzzleObject = GameObject.FindGameObjectsWithTag("PuzzleBox");

        for (index = 0; index < puzzleObject.Length; index++)
        {
            btn.Add(puzzleObject[index].GetComponent<Button>());
            buttonSpin.Add(puzzleObject[index].GetComponent<Animator>());
        }
        AddListener();
        Shuffling();
        funnyWord.SetActive(false);
    }
}