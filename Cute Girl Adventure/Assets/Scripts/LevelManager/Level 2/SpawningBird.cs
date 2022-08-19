using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBird : MonoBehaviour
{
    public GameObject bird;
    public float timeSpawn, rand;

    private void Start()
    {
        rand = Random.Range(3, 5);
        timeSpawn = rand;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSpawn <= 0)
        {
            Instantiate(bird, transform.position, Quaternion.identity);
            rand = Random.Range(3, 5);
            timeSpawn = rand;
        }
        else timeSpawn -= Time.deltaTime;
    }
}
