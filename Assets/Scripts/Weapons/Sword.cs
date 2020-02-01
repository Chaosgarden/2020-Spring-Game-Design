﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    //Sword prototype
    private Animator animator;
    public List<BaseStat> Stats { get; set; }
    public int CurrentDamage { get; set; }
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PerformAttack(int damage)
    {
        Debug.Log("Attacking with Weapon");
        CurrentDamage = damage;
        animator.SetTrigger("Base_Attack");
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col);
        if (col.tag == "Enemy")
        {
            Debug.Log("EnemyTaking Damage");
            col.GetComponent<IEnemy>().TakeDamage(CurrentDamage);
        }
    }
}
