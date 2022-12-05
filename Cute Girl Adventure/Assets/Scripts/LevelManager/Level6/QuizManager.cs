using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField] List<string> question, answerOption, correctAnswer;
    [SerializeField] TextMeshProUGUI[] questionText, optionText;

    int randomQuestionIndex, randomAnswerIndex;
    private void Start()
    {
        randomQuestionIndex = Random.Range(0, question.Count);
        questionText[0].text = question[randomQuestionIndex];

        randomAnswerIndex = randomQuestionIndex * 4;

        for (int i = 0; i < optionText.Length; i++)
        {
            optionText[i].text = answerOption[randomAnswerIndex + i];
        }
    }

    public void ChoosingAnswer(int buttonIndex)
    {
        optionText[buttonIndex].text = answerOption[randomAnswerIndex + buttonIndex];
        if(answerOption[randomAnswerIndex + buttonIndex] == correctAnswer[randomQuestionIndex])
        {
            
        }
    }
}
