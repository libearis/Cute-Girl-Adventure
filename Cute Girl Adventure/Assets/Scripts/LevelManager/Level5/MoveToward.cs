using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    [SerializeField] Vector2 target;
    [SerializeField] Vector2 playerPos;

    private void Start()
    {
        target = GetComponent<Vector2>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Vector2>();
    }
}
