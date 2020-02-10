﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTracker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image healthFill, levelFill;
    [SerializeField] private Text health, level;
    [SerializeField] private Text wavesText;
    void Start()
    {
        UIManager.OnPlayerHealthChanged += UpdateHealth;
        UIManager.OnWaveChanged += UpdateWave;
    }
    void UpdateWave(int waves)
    {
        this.wavesText.text = "Enemies Alive : " + waves.ToString();
    }
    void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.health.text = currentHealth.ToString();
        this.healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}