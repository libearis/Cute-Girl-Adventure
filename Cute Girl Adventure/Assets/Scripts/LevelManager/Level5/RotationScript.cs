using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0,10* Time.deltaTime, Space.World);
    }
}