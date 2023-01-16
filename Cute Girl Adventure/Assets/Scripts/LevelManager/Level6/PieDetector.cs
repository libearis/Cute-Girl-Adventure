using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieDetector : MonoBehaviour
{
    [SerializeField] GameObject pie, mathPanel, historyPanel, nationalPanel, sportPanel, slider;
    [SerializeField] Vector3 angles;
    Rotation rotation;
    public static PieDetector instance;

    private void Start()
    {
        instance = this;
        rotation = GameObject.Find("Pie").GetComponent<Rotation>();
    }
    private void Update()
    {
        angles = pie.transform.rotation.eulerAngles;
        CheckingIfStopped();
    }
    void CheckingIfStopped()
    {
        if (angles.z <= 90 && angles.z >= 0 && rotation.isStopped)
        {
            nationalPanel.SetActive(true);
            nationalPanel.gameObject.GetComponent<QuizManager>().enabled = true;
            rotation.isStopped = false;
            slider.SetActive(true);
        }
        if (angles.z <= 180 && angles.z >= 90 && rotation.isStopped)
        {
            historyPanel.SetActive(true);
            historyPanel.gameObject.GetComponent<QuizManager>().enabled = true;
            rotation.isStopped = false;
            slider.SetActive(true);
        }
        if (angles.z <= 270 && angles.z >= 180 && rotation.isStopped)
        {
            mathPanel.SetActive(true);
            mathPanel.gameObject.GetComponent<QuizManager>().enabled = true;
            rotation.isStopped = false;
            slider.SetActive(true);
        }
        if (angles.z <= 360 && angles.z >= 270 && rotation.isStopped)
        {
            sportPanel.SetActive(true);
            sportPanel.gameObject.GetComponent<QuizManager>().enabled = true;
            rotation.isStopped = false;
            slider.SetActive(true);
        }
    }

    public void RemoveAllQuizPanel()
    {
        nationalPanel.SetActive(false);
        historyPanel.SetActive(false);
        mathPanel.SetActive(false);
        sportPanel.SetActive(false);
    }
}
