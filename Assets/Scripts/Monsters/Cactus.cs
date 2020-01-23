using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour, IEnemy
{
    //enemy prototype
    public float maxHealth = 10;
    public float attack =1;
    public float defense =1;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void PerformAttack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
