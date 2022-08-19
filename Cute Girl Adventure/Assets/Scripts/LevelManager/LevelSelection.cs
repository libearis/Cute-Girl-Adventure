using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public GameObject completePrevText;

    public void LevelSelectionScreen(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void LockedLevel()
    {
        StartCoroutine(Locked());
    }

    IEnumerator Locked()
    {
        completePrevText.SetActive(true);

        yield return new WaitForSeconds(2f);

        completePrevText.SetActive(false);
    }
}
