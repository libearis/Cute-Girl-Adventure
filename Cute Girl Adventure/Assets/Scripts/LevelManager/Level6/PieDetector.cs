using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieDetector : MonoBehaviour
{
    [SerializeField] GameObject pie, mathPanel, historyPanel, nationalPanel, factPanel;
    [SerializeField] Vector3 angles;
    Rotation rotation;

    private void Start()
    {
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
            rotation.isStopped = false;
        }
        if (angles.z <= 180 && angles.z >= 90 && rotation.isStopped)
        {
            historyPanel.SetActive(true);
            rotation.isStopped = false;
        }
        if (angles.z <= 270 && angles.z >= 180 && rotation.isStopped)
        {
            mathPanel.SetActive(true);
            rotation.isStopped = false;
        }
        if (angles.z <= 360 && angles.z >= 270 && rotation.isStopped)
        {
            factPanel.SetActive(true);
            rotation.isStopped = false;
        }
    }
}
