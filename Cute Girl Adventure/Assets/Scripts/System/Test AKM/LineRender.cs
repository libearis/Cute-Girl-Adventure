using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    private LineRenderer lr;
    private RectTransform[] points; 

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(RectTransform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }

    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }
}