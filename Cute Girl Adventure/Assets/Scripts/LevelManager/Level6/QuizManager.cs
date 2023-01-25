using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField] List<string> question, answerOption, correctAnswer, currentAnswerOption;
    [SerializeField] TextMeshProUGUI[] questionText, optionText;
    [SerializeField] GameObject correctImage, wrongImage, quizPanel, statueCutscene;
    [SerializeField] Slider sliderUI;
    [SerializeField] Collider2D rouletteColider;
    [SerializeField] int scoreToWin;
    [SerializeField] Button spinButton;

    int randomQuestionIndex, randomAnswerIndex, score;
    bool quizStarted;
    private void Start()
    {
        randomQuestionIndex = Random.Range(0, question.Count);
        questionText[0].text = question[randomQuestionIndex];

        randomAnswerIndex = randomQuestionIndex * 4;

        for (int i = 0; i < optionText.Length; i++)
        {
            currentAnswerOption.Add(answerOption[randomAnswerIndex + i]);
            optionText[i].text = answerOption[randomAnswerIndex + i];
            print(randomAnswerIndex + i);
        }
    }
    private void Update()
    {
        if(sliderUI.value <= 0)
        {
            wrongImage.SetActive(true);
            StartCoroutine(TimeLimitGoNext());
        }
        if (quizStarted)
        {
            sliderUI.value -= Time.deltaTime;
        }
    }

    public void ChoosingAnswer(int buttonIndex)
    {
        optionText[buttonIndex].text = answerOption[randomAnswerIndex + buttonIndex];
        if(optionText[buttonIndex].text == correctAnswer[randomQuestionIndex])
        {
            correctImage.SetActive(true);
            score++;
        }
        else
        {
            wrongImage.SetActive(true);
        }
    }

    public void NextQuestion()
    {
        StartCoroutine(StartingNextQuestion());
    }    

    IEnumerator StartingNextQuestion()
    {
        question.RemoveAt(randomQuestionIndex);
        correctAnswer.RemoveAt(randomQuestionIndex);
        for (int i = optionText.Length - 1; i >= 0; i--)
        {
            answerOption.RemoveAt(randomAnswerIndex + i);
        }
        questionText[0].text = "";
        optionText[0].text = "";
        optionText[1].text = "";
        optionText[2].text = "";
        optionText[3].text = "";
        quizStarted = false;
        sliderUI.value = 10;

        yield return new WaitForSeconds(1.5f);

        if (score == scoreToWin)
        {
            rouletteColider.enabled = false;
            statueCutscene.GetComponent<StatueMovement>().enabled = true;
            GameObject.Find("Player").GetComponent<GirlMovement>().enabled = true;
            quizPanel.SetActive(false);
        }

        else if (question.Count == 0)
        {
            GameManager.instance.RestartLevel();
        }
        
        else
        {
            correctImage.SetActive(false);
            wrongImage.SetActive(false);
                
            randomQuestionIndex = Random.Range(0, question.Count);
            questionText[0].text = question[randomQuestionIndex];

            randomAnswerIndex = randomQuestionIndex * 4;

            for (int i = 0; i < optionText.Length; i++)
            {
                optionText[i].text = answerOption[randomAnswerIndex + i];
            }
        }
    }

    IEnumerator TimeLimitGoNext()
    {
        question.RemoveAt(randomQuestionIndex);
        correctAnswer.RemoveAt(randomQuestionIndex);
        for (int i = optionText.Length - 1; i >= 0; i--)
        {
            answerOption.RemoveAt(randomAnswerIndex + i);
        }
        questionText[0].text = "";
        optionText[0].text = "";
        optionText[1].text = "";
        optionText[2].text = "";
        optionText[3].text = "";
        quizStarted = false;
        sliderUI.value = 10;

        yield return new WaitForSeconds(1.5f);

        if (question.Count == 0)
        {
            GameManager.instance.RestartLevel();
        }
        else
        {
            correctImage.SetActive(false);
            wrongImage.SetActive(false);

            randomQuestionIndex = Random.Range(0, question.Count);
            questionText[0].text = question[randomQuestionIndex];

            randomAnswerIndex = randomQuestionIndex * 4;

            for (int i = 0; i < optionText.Length; i++)
            {
                optionText[i].text = answerOption[randomAnswerIndex + i];
            }
            quizStarted = true;
        }
    }

    public void QuizStarting()
    {
        quizStarted = true;
    }
}
