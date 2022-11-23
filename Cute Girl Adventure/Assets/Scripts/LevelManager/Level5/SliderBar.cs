using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] RectTransform sliderPos;
    [SerializeField] int speed;
    [SerializeField] GameObject nextButton, startButton, prevButton;

    bool toPage2, toPage1, toPage2Back, toPage3;

    private void Awake()
    {
        sliderPos = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (sliderPos.transform.localPosition.x > -510 && toPage2)
        {
            sliderPos.transform.position += new Vector3(-100, 0, 0) * speed * Time.deltaTime;
        }
        else if (sliderPos.transform.localPosition.x < 0 && toPage1)
        {
            sliderPos.transform.position += new Vector3(100, 0, 0) * speed * Time.deltaTime;
        }
        else if (sliderPos.transform.localPosition.x < -510 && toPage2Back)
        {
            sliderPos.transform.position += new Vector3(100, 0, 0) * speed * Time.deltaTime;
        }
        else if (sliderPos.transform.localPosition.x > -1010 && toPage3)
        {
            sliderPos.transform.position += new Vector3(-100, 0, 0) * speed * Time.deltaTime;
        }

        if(toPage3)
        {
            startButton.SetActive(true);
            nextButton.SetActive(false);
        }
        else
        {
            startButton.SetActive(false);
            nextButton.SetActive(true);
        }
    }

    public void NextPage()
    {
        if (toPage2)
        {
            toPage3 = true;
            toPage2 = toPage1 = false;
            prevButton.SetActive(true);
        }
        else
        {
            toPage1 = toPage3 = false;
            toPage2 = true;
            prevButton.SetActive(true);
        }    
    }

    public void PreviousPage()
    {
        if(toPage2 || toPage2Back)
        {
            toPage1 = true;
            toPage2Back = toPage2 = false;
            prevButton.SetActive(false);
        }
        else
        {
            toPage2Back = true;
            toPage1 = toPage3 = false;
        }
    }
}
