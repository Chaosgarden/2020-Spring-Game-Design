using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;
    public int currentHealth;
    public int maxHealth;
    //public PlayerLevel PlayerLevel { get; set; }

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        Debug.Log("character");
        this.currentHealth = this.maxHealth;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("Player dead. Reset health.");
        Destroy(gameObject);
        this.currentHealth = this.maxHealth;
    }
}
