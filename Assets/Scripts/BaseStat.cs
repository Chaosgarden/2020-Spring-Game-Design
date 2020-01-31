﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
public class BaseStat
{
    public enum BaseStatType { Health, Attack, Dexterity}
    [JsonConverter(typeof(StringEnumConverter))]
    public BaseStatType StatType { get; set; }
    public List<StatBonus> BaseAdd { get; set; }
    public int BaseValue { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set; }

    public BaseStat(int baseValue, string statName, string statDescription)
    {
        this.BaseAdd = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescription;
    }
    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(BaseStatType statType, int baseValue, string statName)
    {
        this.BaseAdd = new List<StatBonus>();
        this.StatType = statType;
        this.BaseValue = baseValue;
        this.StatName = statName;
    }
    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdd.Add(statBonus);
    }
    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.BaseAdd.Remove(BaseAdd.Find(x => x.BonusValue == statBonus.BonusValue));
    }
    public int GetCalculatedStatValue()
    {
        FinalValue = 0;
        this.BaseAdd.ForEach(x => this.FinalValue += x.BonusValue);
        FinalValue += BaseValue;
        return FinalValue;
    }
}
