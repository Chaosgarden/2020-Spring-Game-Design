using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private Text health, level;
    [SerializeField] private Image healthFill, levelFill;
    [SerializeField] private Player player;

    // Stats
    public Text playerPower;
    public Text playerDefense;
    public Text playerSpeed;
    private CharacterStats characterStats;



    void Start()
    {
        UIManager.OnPlayerHealthChanged += UpdateHealth;
        UIManager.OnStatsChanged += UpdateStats;
        UIManager.OnPlayerLevelChange += UpdateLevel;
        UpdateStats();
    }
    void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.health.text = currentHealth.ToString();
        this.healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    void UpdateLevel()
    {
        //this.level.text = player.PlayerLevel.Level.ToString();
        //this.levelFill.fillAmount = (float)player.PlayerLevel.CurrentExperience / (float)player.PlayerLevel.RequiredExperience;
    }

    void InitializeStats()
    {
        
    }

    void UpdateStats()
    {    
        playerPower.text = "Power: " + player.characterStats.stats[0].GetCalculatedStatValue().ToString();
        playerDefense.text = "Defense: " + ": " + player.characterStats.stats[1].GetCalculatedStatValue().ToString();
        playerSpeed.text = "Speed: " + player.characterStats.stats[2].GetCalculatedStatValue().ToString();
    }
}
