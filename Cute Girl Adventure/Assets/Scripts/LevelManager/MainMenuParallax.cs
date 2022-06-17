using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuParallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cam.transform.Translate(Vector2.left * speed * Time.deltaTime);
        float temp = (cam.transform.position.x * (1 - speed));
        float dist = (cam.transform.position.x * speed);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }

    public void Play()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
