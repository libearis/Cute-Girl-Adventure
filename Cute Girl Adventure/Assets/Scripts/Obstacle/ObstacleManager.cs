using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] float speed;
    int damage = 1;
    girlStep girlStep;
    public bool spawningLeft;

    private void Awake()
    {
        girlStep = GameObject.FindWithTag("Player").GetComponent<girlStep>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!spawningLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (girlStep.isGameOver || girlStep.isDone)
        {
            speed = 0;
        }
        if(transform.position.x <= -10)
        {
            Destroy(this.gameObject);
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
