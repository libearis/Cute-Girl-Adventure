using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    // Object References
    [SerializeField] private AnswerValidation bookValue;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private GameObject bookShow;
    [SerializeField] private GameObject answerValidation;

    [SerializeField] private TextMeshProUGUI bookValueText;
    [SerializeField] private TextMeshProUGUI takenText;

    [SerializeField] private Animator deadEnd;

    Rigidbody2D rb;

    // Data Variable
    private bool canBeTaken = false;
    [SerializeField] private string answerValue;

    void Awake()
    {
        bookShow.SetActive(false);
        answerValidation.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Book")
        {
            canBeTaken = true;

            if (canBeTaken)
            {
                bookShow.SetActive(true);
                bookValueText.text = bookValue.value;
            }
        }

        if (collision.tag == "QuestionBox")
        {
            canBeTaken = true;
        }

        if (collision.tag == "Potion")
        {
            Destroy(collision.gameObject);
            playerMovement.jumpForce = 10f;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Book")
        {
            canBeTaken = false;
            bookShow.SetActive(false);
        }

        if (collision.tag == "QuestionBox")
        {
            canBeTaken = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Book")
        {
            if (canBeTaken && Input.GetKeyDown(KeyCode.E))
            {
                answerValue = collision.gameObject.name;
                Destroy(collision.gameObject);
            }
        }
        
        if (collision.tag == "QuestionBox")
        {
            if (canBeTaken && Input.GetKeyDown(KeyCode.E) && answerValue != null)
            {
                playerAttack.enabled = false;
                playerMovement.enabled = false;
                answerValidation.SetActive(true);
                takenText.text = bookValue.value;
            }
            else if (answerValue == null) takenText.text = "No Book Found";
        }
    }

    public void answerCheckingTrue(Collider2D collision)
    {
        if (answerValue == "Book True")
        {
            answerValidation.SetActive(false);
            deadEnd.SetBool("isOpening", true);
            playerAttack.enabled = true;
            playerMovement.enabled = true;
            Destroy(collision.gameObject);
        }
        else takenText.text = "Wrong Answer";
    }    

    public void cancelButton()
    {
        answerValidation.SetActive(false);
        playerAttack.enabled = true;
        playerMovement.enabled = true;
    }
}
