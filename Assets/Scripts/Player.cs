using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;
    public int currentHealth;
    public int maxHealth;
    public bool death = false;
    public int level;
    public int statCounter;
    CharacterStats statPoints;

    void Start()
    {
        statCounter = 0;
        level = 0;
        this.currentHealth = this.maxHealth;
        characterStats = new CharacterStats(10, 10, 10);
        UIManager.PlayerLevelChanged(level);
    }
    public void LevelUp()
    {
        if (level >= 1)
        { }
        else
        {
            statCounter++;
        }
        level++;
        this.currentHealth = 10;
        UIManager.HealthChanged(currentHealth,maxHealth);
        UIManager.PlayerLevelChanged(level);
        UIManager.PlayerStatCounter();
    }
    public void AddPower()
    {
        if(statCounter > 0)
        {
            statPoints = new CharacterStats(5, 0, 0);
            characterStats.AddStatBonus(statPoints.stats);
            UIManager.StatChange();
            statCounter--;
            UIManager.PlayerStatCounter();

        }
    }
    public void AddToughness()
    {
        
        if (statCounter > 0)
        {
            statPoints = new CharacterStats(0, 1, 0);
            characterStats.AddStatBonus(statPoints.stats);
            UIManager.StatChange();
            statCounter--;
            UIManager.PlayerStatCounter();

        }
    }
    public void AddSpeed()
    {
        if (statCounter > 0)
        {
            statPoints = new CharacterStats(0, 0, 1);
            characterStats.AddStatBonus(statPoints.stats);
            UIManager.StatChange();
            statCounter--;
            UIManager.PlayerStatCounter();
        }
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
        UIManager.Instance.Defeat();
        Debug.Log("Player dead. Reset health.");
        Destroy(gameObject);
    }
}
