using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }
    WeaponController playerWeaponController;
    public Item sword;
    public List<Item> playerItem = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        playerWeaponController = GetComponent<WeaponController>();
        GiveItem("sword");
    }

    public void GiveItem(string itemSlug)
    {   
        sword = Database.Instance.GetItem(itemSlug);
        playerItem.Add(sword);
        EquipItem(sword);        
    }
    public void SetItemDetails(Item item, Button selectedButton)
    {
        //inventoryDetailsPanel.SetItem(item, selectedButton);
    }

    public void EquipItem(Item itemToEquip)
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }
    void Update()
    {

    }
}
