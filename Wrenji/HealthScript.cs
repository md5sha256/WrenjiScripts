using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthScript : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    public abstract void onEntityDie();

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            onEntityDie();
        }
    }

    
}
