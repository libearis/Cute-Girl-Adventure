using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class girlStep : MonoBehaviour
{
    public string loadToScene;
    public bool isDone;
    [SerializeField] Spawning spawning;
    [SerializeField] private Vector2 targetPos;
    [SerializeField] private float speed;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;
    [SerializeField] private float sidePower;
    public int currentHealth = 3, retrychances;

    public int starCount = 0, maxStar;
    public TextMeshProUGUI starText, retryText;

    public bool isFinish = false;
    public bool isGameOver = false;

    public GameObject[] healthIcon;
    public GameObject gameOverPanel, homeButton;
    public GameObject winPanel; 

    public Animator anim;
    public Animator sceneTransition;

    private void Awake()
    {
        starText = GameObject.Find("StarText").GetComponent<TextMeshProUGUI>();
        retrychances = PlayerPrefs.GetInt("Health", 2);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 4 && !isDone)
        {
            transform.position += new Vector3(0, 0.05f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -4 && !isDone)
        {
            transform.position += new Vector3(0, -0.05f, 0);
        }

        if(currentHealth == 0)
        {
            gameOverPanel.SetActive(true);

            if(retrychances == 0)
            {
                isGameOver = true;
                anim.enabled = false;
                homeButton.SetActive(true);
                retryText.text = "Retry Chance = 0" ;

            }
            else
            {
                isGameOver = true;
                anim.enabled = false;
                retryText.text = "Retry Chance = " + retrychances.ToString();
            }
            this.gameObject.GetComponent<girlStep>().enabled = false;
        }

        if(starCount == maxStar)
        {
            StartCoroutine(challengeDone());
        }
    }

    public void TakeDamage()
    {
        Destroy(healthIcon[currentHealth - 1]);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        retrychances--;
        PlayerPrefs.SetInt("Health", retrychances);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Star")
        {
            starCount++;
            starText.text = "X " + starCount.ToString();
            Destroy(collision.gameObject);
        }
    }

    IEnumerator challengeDone()
    {
        winPanel.SetActive(true);
        isDone = true;
        anim.enabled = false;
        spawning.enabled = false;

        yield return new WaitForSeconds(2f);
        
        sceneTransition.SetTrigger("End");

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(loadToScene);
    }
}
