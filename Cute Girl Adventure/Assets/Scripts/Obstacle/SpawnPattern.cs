using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPattern : MonoBehaviour
{
    public GameObject obstacles;

    void Start()
    {
        Instantiate(obstacles, transform.position, Quaternion.identity);
    }

}
