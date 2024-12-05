using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public TextMeshProUGUI playerHealthUI;
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthUI.text = $"{currentHealth}%";
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
            playerHealthUI.text = $"{currentHealth}%";
    }

    void Die()
    {
        GetComponent<MouseMovement>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
    }
}
