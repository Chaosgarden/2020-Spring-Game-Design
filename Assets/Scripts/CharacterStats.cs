using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();
    public string healthName = "Vitality";
    public string healthDesc = "Your health";

    public string attName = "Attack";
    public string attDesc = "Your Damage";

    public string speedName = "Dexterity";
    public string speedDesc = "Your Speed";

    public int level;
    public CharacterStats(int health, int attack, int speed)
    {
        stats = new List<BaseStat>() {
            new BaseStat(BaseStat.BaseStatType.Health, health, healthDesc),
            new BaseStat(BaseStat.BaseStatType.Attack, attack, attDesc),
            new BaseStat(BaseStat.BaseStatType.Dexterity, speed, speedDesc)
        };      
    }
    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        Debug.Log(stats);
        Debug.Log(stats.Find(x => x.StatType == stat));
        stats.Find(x => x.StatType == stat);
        
        return stats.Find(x => x.StatType == stat);
    }

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            Debug.Log(stats[1].StatType);
            stats.Find(x=> x.StatType == statBonus.StatType)
                .AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            stats.Find(x => x.StatName == statBonus.StatName)
                .RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}
