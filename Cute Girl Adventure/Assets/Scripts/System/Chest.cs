using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    public static Chest instance;
    private void Awake()
    {
        instance = this;
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    public void DestroyCollider()
    {
        boxCollider2D.enabled = false;
    }
}
