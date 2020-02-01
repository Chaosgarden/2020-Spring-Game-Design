using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NghiaScript : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public GameObject player;
    float attackRange = 2f;
    IEnemy cactus;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
        {
            FindObjectOfType<Cactus>().PerformAttack();
        }

        else {
            agent.SetDestination(player.transform.position);
        }
    }
}
