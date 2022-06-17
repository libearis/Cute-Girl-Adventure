using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    float currentHealth;
    float maxHealth = 3f;

    [SerializeField] Image currentHealthBar;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        currentHealthBar.fillAmount = currentHealth / 10;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
