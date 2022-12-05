using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [HideInInspector] public bool isSlowingDown, isStopped;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        if (isSlowingDown && rotationSpeed >= 0)
        {
            rotationSpeed -= Random.Range(100, 400) * Time.deltaTime;
        }
        if(rotationSpeed < 0)
        {
            isSlowingDown = false;
            rotationSpeed = 0;
            isStopped = true;
        }
    }
    public void SlowingDown()
    {
        isSlowingDown = true;
    }
   
}
