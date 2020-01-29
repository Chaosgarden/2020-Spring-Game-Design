using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }
    CharacterStats characterStats;
    IWeapon equippedWeapon;
    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
    }
    public void EquipWeapon(Item itemToEquip)
    {
        /*deleting equiped weapon 
         if (EquippedWeapon != null)
         {
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
         }   
        */
        //equiping the weapon on the playerHand and having it follow;
        if (EquippedWeapon == null)
        { 
            /*EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapon/" + itemToEquip.ObjecSlug),
                playerHand.transform.position, playerHand.transform.rotation, playerHand.transform);*/
            equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
            equippedWeapon.Stats = itemToEquip.Stats;
            weapon.transform.SetParent(playerHand.transform);
            characterStats.AddStatBonus(itemToEquip.Stats);
        }
    }
    public void PerformWeaponAttack()
    {
            equippedWeapon.PerformAttack();    
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PerformWeaponAttack();
        }
    }
}
