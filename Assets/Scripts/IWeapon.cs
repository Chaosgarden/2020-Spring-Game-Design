using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    //interface for Weapon
    List<BaseStat> Stats { get; set; }
    void PerformAttack();
}
