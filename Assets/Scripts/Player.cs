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
        //PlayerLevel = GetComponent<PlayerLevel>();
        Debug.Log("character");
        this.currentHealth = this.maxHealth;
    }
    public void Inits()
    {
        characterStats = new CharacterStats(10, 10, 10);
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
        this.currentHealth = this.maxHealth;
    }
}
