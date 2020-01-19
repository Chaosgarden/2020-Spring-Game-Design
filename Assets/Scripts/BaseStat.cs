using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat
{
    public List<StatBonus> BaseAdd { get; set; }
    public int BaseValue { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set; }

    public BaseStat(int baseValue, 
                    string statName, 
                    string statDescription)
    {
        this.BaseAdd = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = StatDescription;
    }
    public void AddStattBonus(StatBonus statBonus)
    {
        this.BaseAdd.Add(statBonus);
    }
    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.BaseAdd.Remove(BaseAdd.Find(x => x.BonusValue == statBonus.BonusValue));
    }
    public int GetCalculatedStatValue()
    {
        this.BaseAdd.ForEach(x => this.FinalValue += x.BonusValue);
        FinalValue += BaseValue;
        return FinalValue;
    }
}
