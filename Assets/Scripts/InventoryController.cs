using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public WeaponController playerWeaponController;
    public Item sword;
    // Start is called before the first frame update
    void Start()
    {
        //creation of the weapons
        playerWeaponController = GetComponent<WeaponController>();
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(1, "Damage", "Your Damage"));
        sword = new Item(swordStats, "sword");
        playerWeaponController.EquipWeapon(sword);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
