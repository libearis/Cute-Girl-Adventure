using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject[] obstaclePattern;
    float timeSpawn;
    [SerializeField] float startTimeSpawn;
    bool isStarted;

    private void Start()
    {
        timeSpawn = startTimeSpawn;
    }

    void Update()
    {
        if(isStarted)
        {
            if (timeSpawn <= 0)
            {
                int rand = Random.Range(0, obstaclePattern.Length);
                Instantiate(obstaclePattern[rand], transform.position, Quaternion.identity);
                timeSpawn = startTimeSpawn;
            }

            else timeSpawn -= Time.deltaTime;
        }
    }

    public void GameStarting()
    {
        isStarted = true;
    }
}
