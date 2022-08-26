using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public static Bullet instance;

    float fireRate, fireTimer;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        fireTimer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * 10;
    }

    public void SpawningBullet(GameObject prefab, Transform firePosition)
    {
        
    }    
}
