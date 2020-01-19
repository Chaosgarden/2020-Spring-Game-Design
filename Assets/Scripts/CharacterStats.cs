using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();
    public int health = 5;
    public string healthName = "Health";
    public string healthDesc = "Your health";
    public int attack;
    public int level;
    void Start()
    {
        stats.Add(new BaseStat(health, healthName, healthDesc));
        stats.Add(new BaseStat(5, "Vitality", "Weewoo"));

    }
    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            stats.Find(x=> x.StatName == statBonus.StatName)
                .AddStattBonus(new StatBonus(statBonus.BaseValue));
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
