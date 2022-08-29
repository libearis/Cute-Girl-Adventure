using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class ChallengeManagerLevel4 : MonoBehaviour
{
    DataSoal dataSoal;

    [SerializeField] string[] questionList, answerList, correctAnswerList;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI[] optionText;

    public List<string> questionOnline;
    public string currentCorrectAnswer;

    public int index, randomNumber;
    private void Start()
    {
        
        randomNumber = Random.Range(0, 4);
        questionText.text = questionList[randomNumber];
        currentCorrectAnswer = correctAnswerList[randomNumber];
        Debug.Log(randomNumber);
        randomNumber *= 3;
        Debug.Log(randomNumber);
        for(int i = 0; i < optionText.Length; i++)
        {
            optionText[i].text = answerList[randomNumber];
            randomNumber++;
        }
        randomNumber -= 3;
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
                    dataSoal = JsonUtility.FromJson<DataSoal>(webRequest.downloadHandler.text);
                    foreach (DetailSoal data in dataSoal.result)
                    {
                        questionOnline.Add(data.question);
                    }
                    break;
            }
        }
    }
}
