using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }
    IWeapon equippedWeapon;
    public CharacterStats characterStats;
    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
    }
    public void EquipWeapon(Item itemToEquip)
    {     
        
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Collections/" + itemToEquip.ObjectSlug),
            playerHand.transform.position, playerHand.transform.rotation);
            
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        EquippedWeapon.transform.SetParent(playerHand.transform);
        equippedWeapon.Stats = itemToEquip.Stats;
        Debug.Log(itemToEquip);
        Debug.Log(characterStats);
        characterStats.AddStatBonus(itemToEquip.Stats);
    }
  
    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack(CalculateDamage());
    }
    private int CalculateDamage()
    {
        int damageToDeal = (characterStats.GetStat(BaseStat.BaseStatType.Attack).GetCalculatedStatValue() * 2)
            + Random.Range(2, 8);
        Debug.Log("Damage dealt: " + damageToDeal);
        return damageToDeal;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PerformWeaponAttack();
        }
    }
}
