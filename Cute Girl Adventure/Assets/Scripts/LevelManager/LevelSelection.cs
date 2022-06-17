using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public GameObject completePrevText;

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
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
