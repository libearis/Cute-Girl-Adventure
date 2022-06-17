using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stars : MonoBehaviour
{
    [SerializeField] float speed;
    girlStep girlStep;

    private void Awake()
    {
        girlStep = GameObject.FindWithTag("Player").GetComponent<girlStep>();
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }

        if (girlStep.isGameOver || girlStep.isDone)
        {
            speed = 0;
        }
    }

}
