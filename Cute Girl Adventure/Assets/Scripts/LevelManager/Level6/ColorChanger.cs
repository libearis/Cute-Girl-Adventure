using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] Color textColor, originalColor;
    TextMeshProUGUI spinText;
    public static ColorChanger instance;

    private void Start()
    {
        instance = this;
    }
    public void ChangingColorText()
    {
        spinText = GetComponent<TextMeshProUGUI>();
        spinText.color = textColor;
    }

    public void ChangingBack()
    {
        spinText.color = originalColor;
    }
}
