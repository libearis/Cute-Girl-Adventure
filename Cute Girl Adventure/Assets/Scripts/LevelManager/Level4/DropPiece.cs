using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPiece : MonoBehaviour, IDropHandler
{
    [SerializeField] string pieceName;
    [SerializeField] PuzzleManager puzzleManager;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null && eventData.pointerDrag.name == pieceName)
        {
            print("Benar");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<DragingPiece>().enabled = false;
            puzzleManager.score++;
        }
        else
        {
            print("null");
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = eventData.pointerDrag.GetComponent<DragingPiece>().originalPos;
        }
    }
}
