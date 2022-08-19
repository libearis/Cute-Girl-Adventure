using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonManager : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IPointerExitHandler
{
    public TextMeshProUGUI buttonDescription = null;
    public string descriptionName;
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonDescription.text = descriptionName;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonDescription.text = "";
    }
    public void OnSelect(BaseEventData eventData)
    {
        //do your stuff when selected
    }
}