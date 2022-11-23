using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Vector3 forward;

    [SerializeField] float speed;

    public SpriteRenderer[] image;
    public int[] index;

    public Color successColor;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.x >= -2.2f && transform.position.x <= -1.9f)  
        {
            image[index[0]].color = successColor;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && transform.position.x >= 1.15f && transform.position.x <= 1.5f)
        {
            image[index[1]].color = successColor;
        }

        forward = transform.position;
        forward.x += speed;
        transform.position = forward;

        if (transform.position.x <= -4)
        {
            speed = -speed;
        }

        else if (transform.position.x >= 3.5)
        {
            speed = -speed;
        }
    }
}
