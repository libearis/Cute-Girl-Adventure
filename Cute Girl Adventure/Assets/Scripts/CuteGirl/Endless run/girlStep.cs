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
    public GameObject panel, homeButton;
    public GameObject winPanel; 

    public Animator anim;
    public Animator sceneTransition;

    private void Awake()
    {
        starText = GameObject.Find("StarText").GetComponent<TextMeshProUGUI>();
        retrychances = PlayerPrefs.GetInt("Health");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + sidePower);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - sidePower);
        }

        if(currentHealth == 0)
        {
            panel.SetActive(true);
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
