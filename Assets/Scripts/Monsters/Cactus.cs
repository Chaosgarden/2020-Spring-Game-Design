using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cactus : MonoBehaviour, IEnemy
{
    public float currentHealth;
    public float maxHealth;
    private NavMeshAgent agent;
    private CharacterStats characterStats;
    //private Player player;
    GameObject playerHolder;
    Player player;
    public HealthBar healthBar;
    public DamagePopup damagePopup;
    void Awake()
    {
        characterStats = new CharacterStats(6, 10, 2);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentHealth = maxHealth;
        playerHolder = GameObject.Find("Player");
        player = playerHolder.GetComponent<Player>();
        //player = GameObject.Find("Player");
        healthBar.SetMaxHealth((int)maxHealth);
    }

    void FixedUpdate()
    {
        if(player.death != true)
        {
            ChasePlayer(player);
        }
    }

    public void PerformAttack()
    {       
        player.TakeDamage(1);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        damagePopup.Create(transform.position, amount);
        healthBar.SetHealth((int)currentHealth);
        if (currentHealth <= 0)
        {
            Die();

        }
    }

    void ChasePlayer(Player player)
    {
        agent.SetDestination(player.transform.position);
        this.player = player;
        if (agent.remainingDistance <= agent.stoppingDistance + 5f) 
        {
            if (!IsInvoking("PerformAttack"))
            {
                InvokeRepeating("PerformAttack", .5f, 2f);
                agent.isStopped = true;
            }
        }
        else
        {
            agent.isStopped = false;
            CancelInvoke("PerformAttack");
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
 
}
