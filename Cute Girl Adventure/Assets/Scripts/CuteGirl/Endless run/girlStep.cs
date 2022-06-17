using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class girlStep : MonoBehaviour
{
    public bool isDone;
    [SerializeField] Spawning spawning;
    [SerializeField] private Vector2 targetPos;
    [SerializeField] private float speed;
    [SerializeField] private float minHeight;
    [SerializeField] private float maxHeight;
    [SerializeField] private float sidePower;
    public int currentHealth = 3;

    public int starCount = 0;
    public TextMeshProUGUI starText;

    public bool isFinish = false;
    public bool isGameOver = false;

    public GameObject[] healthIcon;
    public GameObject panel;
    public GameObject winPanel; 

    public Animator anim;

    private void Awake()
    {
        starText = GameObject.Find("StarText").GetComponent<TextMeshProUGUI>();
        Time.timeScale = 0;
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
            isGameOver = true;
            anim.enabled = false;
        }

        if(starCount == 20)
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
    public void PlayButton()
    {
        Time.timeScale = 1;
    }

    IEnumerator challengeDone()
    {
        winPanel.SetActive(true);
        isDone = true;
        anim.enabled = false;
        spawning.enabled = false;

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Tutorial Finish");
    }
}
