using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] Color textColor;
    TextMeshProUGUI spinText;
    public void ChangingColorText()
    {
        spinText = GetComponent<TextMeshProUGUI>();
        spinText.color = textColor;
    }
}
