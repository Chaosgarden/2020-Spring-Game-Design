using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTracker : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image healthFill, levelFill;
    [SerializeField] private Text health, level;
    void Start()
    {
        UIManager.OnPlayerHealthChanged += UpdateHealth;
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
