using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int progressionValue;
    public Animator sceneTransition;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        progressionValue = 6;
    }
    public void SavingProgression(int currentScreenValue)
    {
        if(progressionValue < currentScreenValue)
        {
            progressionValue = currentScreenValue;
            PlayerPrefs.SetInt("Progression", progressionValue);
        }
        else PlayerPrefs.SetInt("Progression", progressionValue);
    }
    public void CheckingProgression()
    {
        if (progressionValue == 0)
        {
            StartCoroutine(SceneTransition("Tutorial"));
        }
        else StartCoroutine(SceneTransition("LevelSelection" + progressionValue));
    }

    public void ChangingScene(string screenName)
    {
        StartCoroutine(SceneTransition(screenName));
    }

    public void PausingTheGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DeletingPref()
    {
        PlayerPrefs.DeleteAll();
    }

    IEnumerator SceneTransition(string screenName)
    {
        sceneTransition.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(screenName);
    }

    private void OnApplicationQuit()
    {
        DeletingPref();
        SavingProgression(progressionValue);
    }
}
