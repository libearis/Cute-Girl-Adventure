using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Object References
    [SerializeField] private GameObject cinemachine;

    // Data Variable
    
    void Awake()
    {
        cinemachine.SetActive(false);
        StartCoroutine(showCam());
    }

    IEnumerator showCam()
    {
        yield return new WaitForSeconds(1.7f);
        cinemachine.SetActive(true);
    }


}
