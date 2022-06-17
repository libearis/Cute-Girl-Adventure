using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public GameObject clickAnywhere;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    private float typingSpeed;

    public IEnumerator TypingDialogue()
    {
        yield return new WaitForSeconds(1f);
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(1f);
        clickAnywhere.SetActive(true);
    }

    public void changingDialogue()
    {
        sentences[index] = "Bagus, sekarang tekan 'G' di tombol pertanyaan untuk menjawab pertanyaan dan menyelesaikan level tutorial ini!!";
    }
}
