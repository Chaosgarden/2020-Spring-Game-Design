using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cactus : MonoBehaviour, IEnemy
{
    //enemy prototype
    private int currentHealth = 20;
    private int attack = 5;
    private int maxHealth;
    public NavMeshAgent agent;
    //public GameObject player;
    void Start()
    {
        currentHealth = maxHealth;
        //player = GameObject.Find("Player");
    }

    public void PerformAttack()
    {

    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Pieeeee");
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
    void FixedUpdate()
    {
        /*
        if (Vector3.Distance(transform.position, player.transform.position) < 2)
        {
            PerformAttack();
        }
        else
        {
            agent.SetDestination(player.transform.position);
        }
        */
    }
}
