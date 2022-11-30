using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    bool isSlowingDown;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        if (isSlowingDown && rotationSpeed >= 0)
        {
            rotationSpeed -= Random.Range(30, 100) * Time.deltaTime;
        }
        if(rotationSpeed < 0)
        {
            isSlowingDown = false;
            rotationSpeed = 0;
        }
    }
    public void SlowingDown()
    {
        isSlowingDown = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
