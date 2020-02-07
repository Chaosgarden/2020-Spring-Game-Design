using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;
    public int currentHealth;
    public int maxHealth;
    public bool death = false;
    //public PlayerLevel PlayerLevel { get; set; }

    void Awake()
    {
        this.currentHealth = this.maxHealth;
        characterStats = new CharacterStats(10, 10, 10);
        UIManager.HealthChanged(this.currentHealth, this.maxHealth);
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UIManager.HealthChanged(this.currentHealth, this.maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        death = true;
        Debug.Log("Player dead. Reset health.");
        this.currentHealth = this.maxHealth;
       
        Destroy(gameObject);
    }
}
