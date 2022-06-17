using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] float speed;
    int damage = 1;
    girlStep girlStep;


    private void Awake()
    {
        girlStep = GameObject.FindWithTag("Player").GetComponent<girlStep>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(transform.position.x <= -10)
        {
            Destroy(gameObject);
        }

        if(girlStep.isGameOver || girlStep.isDone)
        {
            speed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<girlStep>().TakeDamage();
            collision.GetComponent<girlStep>().currentHealth -= damage;

            Destroy(gameObject);
        }
    }
}
