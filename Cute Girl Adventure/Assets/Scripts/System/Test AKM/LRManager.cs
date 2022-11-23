using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRManager : MonoBehaviour
{
    [SerializeField] private RectTransform[] points;
    [SerializeField] private LineRender line;

    private void Start()
    { 
        line.SetUpLine(points); 
    }
}
