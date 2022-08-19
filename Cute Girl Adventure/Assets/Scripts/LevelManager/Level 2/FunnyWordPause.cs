using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class FunnyWordPause : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Time.timeScale = 0;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Time.timeScale = 1;
    }
}
