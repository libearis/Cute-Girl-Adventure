using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class API : MonoBehaviour
{
    /*IEnumerator GetRequest(string uri)
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
                    detailSoal = JsonUtility.FromJson<detailSoal>(webRequest.downloadHandler.text);
                    foreach (detailData data in detailSoal.result.data)
                    {
                        questionList.Add(data.question);
                        questionId.Add(data.quiz_id.ToString());
                        foreach (Option option in data.options)
                        {
                            optionList.Add(option.description);
                            optionId.Add(option.quiz_id.ToString());
                            correct_answer.Add(option.correct_answer);
                            j++;
                        }
                    }
                    break;
            }
        }
    }*/
}
