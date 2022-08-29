using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class API : MonoBehaviour
{
    DataSoal dataSoal;
    Trigger girlTrigger;

    public GameObject congratulationPanel;
    public List<string> questionList, optionList, correctOption, currentQuestion, currentOption, currentCorrectOption;
    public List<int> levelNumber;
    [SerializeField] TextMeshProUGUI[] questionText, trueAnswer, wrongAnswer;

    public int currentLevel;

    int index, i, randomWrong;

    public string answerValidate;

    private void Awake()
    {
        girlTrigger = GameObject.FindWithTag("Player").GetComponent<Trigger>(); 
        StartCoroutine(GetRequest("https://dev.edigy.id/api/v1/gamification/quizzes"));
    }

    private void Start()
    {
        /*for(index = 0; index < levelNumber.Count; index++)
        {
            if(levelNumber[index] == currentLevel)
            {
                print("dapat");
                currentQuestion.Add(questionList[index]);
                for(int i = index * 5; i < index * 5 + 5; i++)
                {
                    currentOption.Add(optionList[i]);
                    currentCorrectOption.Add(correctOption[i]);
                }
            }
        }
        for(i = 0; i < currentQuestion.Count; i ++)
        {
            questionText[i].text = currentQuestion[i];
            for(index = i * 5; index < i * 5 + 5; index++)
            {
                if(currentCorrectOption[index] == "1")
                {
                    trueAnswer[i].text = currentOption[index];
                    currentOption.RemoveAt(index);
                }
            }
            index -= 5;
            randomWrong = Random.Range(index, currentOption.Count);
            Debug.Log(currentOption[randomWrong]);
            wrongAnswer[0].text = currentOption[randomWrong];
        }*/
    }

    private void FixedUpdate()
    {
        if (girlTrigger.questionSee && answerValidate == "30"&& Input.GetKeyDown(KeyCode.G))
        {
            congratulationPanel.SetActive(true);
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
                        levelNumber.Add(data.level_number);
                        questionList.Add(data.question);
                        foreach (DetailOpsi opsi in data.options)
                        {
                            optionList.Add(opsi.description);
                            correctOption.Add(opsi.correct_answer);
                        }    
                    }
                    for (index = 0; index < levelNumber.Count; index++)
                    {
                        if (levelNumber[index] == currentLevel)
                        {
                            print("dapat");
                            currentQuestion.Add(questionList[index]);
                            for (int i = index * 5; i < index * 5 + 5; i++)
                            {
                                currentOption.Add(optionList[i]);
                                currentCorrectOption.Add(correctOption[i]);
                            }
                        }
                    }
                    for (i = 0; i < currentQuestion.Count; i++)
                    {
                        questionText[i].text = currentQuestion[i];
                        for (index = i * 5; index < i * 5 + 5; index++)
                        {
                            if (currentCorrectOption[index] == "1")
                            {
                                trueAnswer[i].text = currentOption[index];
                                currentOption.RemoveAt(index);
                            }
                        }
                        index -= 5;
                        randomWrong = Random.Range(index, currentOption.Count);
                        Debug.Log(currentOption[randomWrong]);
                        wrongAnswer[0].text = currentOption[randomWrong];
                    }
                    break;
            }
        }
    }

    public void AnswerValidation(int counting)
    {
        answerValidate = trueAnswer[counting].text;
    }
}
