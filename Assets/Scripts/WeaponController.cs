using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }
    IWeapon equippedWeapon;
    public CharacterStats characterStats;
    public Animator animator;
    public NghiaScript movement;

    void Start()
    {
        characterStats = GetComponent<Player>().characterStats;
        movement = GetComponent<NghiaScript>();
        if(animator != null)
        {
            animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        }
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
        /*if(animator != null)
        {
            animator.SetTrigger("Attacking");
        }*/
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
        PerformWeaponAttack();
        if (animator != null)
        {
            animator.SetInteger("condition", 2);
            movement.isAttacking = true;            
            yield return new WaitForSeconds(2f);
            movement.isAttacking = false;
            animator.SetInteger("condition", 0);
        }
    }
}
