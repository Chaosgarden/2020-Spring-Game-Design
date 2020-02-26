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
    public bool invulnerable;
    CharacterStats statPoints;

    void Start()
    {
        statCounter = 1;
        level = 0;
        this.currentHealth = this.maxHealth;
        characterStats = new CharacterStats(10, 10, 10);
        UIManager.PlayerLevelChanged(level);
    }
    public void LevelUp()
    {
        statCounter++;
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
        
        invulnerable = true;
        counter();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    IEnumerator counter()
    {
        invulnerable = false;
        yield return new WaitForSeconds(0.5F); 
    }
    private void Die()
    {
        death = true;
        UIManager.Instance.Defeat();
        Debug.Log("Player dead. Reset health.");
        //Destroy(gameObject);
    }
}
