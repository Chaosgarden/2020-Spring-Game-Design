using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }
    IWeapon equippedWeapon;
    CharacterStats characterStats;
    public Animator animator;
    void Start()
    {
        characterStats = GetComponent<Player>().characterStats;
    }
    public void EquipWeapon(Item itemToEquip)
    {     
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug),
            playerHand.transform.position, playerHand.transform.rotation);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        EquippedWeapon.transform.SetParent(playerHand.transform);
        equippedWeapon.Stats = itemToEquip.Stats;
        characterStats.AddStatBonus(itemToEquip.Stats);
        Debug.Log("Equipping :" + EquippedWeapon);
    }
  
    public void PerformWeaponAttack()
    {
        animator.SetTrigger("Attacking");
        equippedWeapon.PerformAttack(CalculateDamage());
    }
    private int CalculateDamage()
    {        
        int damageToDeal = (characterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue())
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
