using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour
{
    [SerializeField] float speed, timeDeath;
    int damage = 1;
    public bool spawningLeft;

    private void Awake()
    {
        timeDeath = 7;
    }
    // Update is called once per frame
    void Update()
    {
        if (!spawningLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); 
        } 
        if(timeDeath <= 0)
        {
            Destroy(this.gameObject);
            timeDeath = 7;
        }
        timeDeath -= Time.deltaTime;
    }
}
