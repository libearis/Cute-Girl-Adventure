using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float x, y;

    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(x, y) * Time.deltaTime, _img.uvRect.size);
        if(_img.uvRect.position.x >= 0.2f && _img.uvRect.position.y >= 0.2f)
        {
            x = y = -0.01f;
        }
        else if (_img.uvRect.position.x <= -0.2f && _img.uvRect.position.y <= -0.2f)
        {
            x = y = 0.01f;
        }
    }
}