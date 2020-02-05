using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cactus : MonoBehaviour, IEnemy
{
    private int currentHealth = 20;
    private int attack = 5;
    private int maxHealth;
    public NavMeshAgent agent;
    GameObject player;
    Player playerVar;
    void Awake()
    {
        currentHealth = maxHealth;
        player = GameObject.Find("Player");
        playerVar = player.GetComponent<Player>();
        //player = GameObject.Find("Player");
    }

    public void PerformAttack()
    {
        playerVar.TakeDamage(5);
    }
    public void TakeDamage(int amount)
    {     
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void Update()
    {
       
        if (Vector3.Distance(transform.position, player.transform.position) < 2.3f)
        {
            PerformAttack();
        }
        else
        {
            agent.SetDestination(player.transform.position);
        }
       
    }
}
