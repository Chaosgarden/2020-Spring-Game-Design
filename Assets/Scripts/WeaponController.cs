using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }
    IWeapon equippedWeapon;
    public CharacterStats characterStats;
    public Animator anim;
    NghiaScript  movement;
    void Start()
    {
        characterStats = GetComponent<Player>().characterStats;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<NghiaScript>();
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

            StartCoroutine(Attacking());

        }
    }
    IEnumerator Attacking()
    {
        
            
            anim.SetInteger("condition", 2);
            PerformWeaponAttack();
            movement.isAttacking = true;
            yield return new WaitForSeconds(2f);
            movement.isAttacking = false;
            anim.SetInteger("condition", 0);

        
    }
}
