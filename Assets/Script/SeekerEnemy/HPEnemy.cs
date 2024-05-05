using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPEnemy : MonoBehaviour
{
    public float hp = 10f;
    private bool isAttacked = false; // Flag to check if enemy is attacked

    // Function to take damage
    public void TakeDamage(float damage)
    {
        hp -= damage;

        // Check if HP is less than or equal to zero
        if (hp <= 0)
        {
            Die();
        }

        // Reset flag after being attacked
        isAttacked = false;
    }

    // Function to handle death
    void Die()
    {
        Destroy(gameObject);
    }

    // Set flag when enemy is attacked
    public void SetAttacked()
    {
        isAttacked = true;
    }
}