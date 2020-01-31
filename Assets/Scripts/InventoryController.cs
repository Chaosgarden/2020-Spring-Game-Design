using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
 
    WeaponController playerWeaponController;
    public Item sword;
    public List<Item> playerItem = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        playerWeaponController = GetComponent<WeaponController>();
        GiveItem("sword");
    }

    public void GiveItem(string itemSlug)
    {   
        sword = Database.Instance.GetItem(itemSlug);
        playerItem.Add(sword);
        EquipItem(sword);
        
    }
    public void EquipItem(Item itemToEquip)
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }
    void Update()
    {

    }
}
