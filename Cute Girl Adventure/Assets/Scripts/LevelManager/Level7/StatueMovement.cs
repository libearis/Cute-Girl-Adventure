using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueMovement : MonoBehaviour
{
    public float shackingRate, duration, vertical, max, min;

    void Update()
    {
        if (transform.position.x >= max)
        {
            shackingRate = -shackingRate;
        }
        else if (transform.position.x <= min)
        {
            shackingRate = (Mathf.Abs(shackingRate));
        }
        transform.position += new Vector3(shackingRate, 0, 0);
        duration += Time.deltaTime;
        if (duration >= 2)
        {
            shackingRate = 0;
            vertical = -0.15f;
            transform.position += new Vector3(0, vertical, 0);
            if(duration >=3.5f)
            {
                vertical = 0;
            }
        }
    }
}
