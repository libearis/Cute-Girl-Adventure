using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class ChallengeManager : MonoBehaviour
{
    [SerializeField] string[] questionList, answerList, correctAnswerList;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI[] optionText;

    public string currentCorrectAnswer;

    public int index, randomNumber;
    private void Start()
    {
        StartCoroutine(GetRequest("https://dev.edigy.id/api/v1/gamification/quizzes"));
        randomNumber = Random.Range(0, 4);
        questionText.text = questionList[randomNumber];
        currentCorrectAnswer = correctAnswerList[randomNumber];
        Debug.Log(randomNumber);
        randomNumber *= 3;
        randomNumber -= 1;
        Debug.Log(randomNumber);
        for(int i = 0; i < answerList.Length; i++)
        {
            randomNumber++;
            optionText[i].text = answerList[randomNumber];
        }
        randomNumber = randomNumber - 3;
    }

    public void CheckingAnswer(int arrayOfOption)
    {
        if(answerList[randomNumber+arrayOfOption] == currentCorrectAnswer)
        {
            print("benar");
        }
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
