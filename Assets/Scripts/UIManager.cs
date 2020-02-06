using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Player playerHolder;
    public GameObject restartUI;
    public GameObject victoryUI;

    public delegate void PlayerHealthEventHandler(int currentHealth, int maxHealth);
    public static event PlayerHealthEventHandler OnPlayerHealthChanged;

    public delegate void StatsEventHandler();
    public static event StatsEventHandler OnStatsChanged;

    public delegate void PlayerLevelEventHandler();
    public static event PlayerLevelEventHandler OnPlayerLevelChange;

    void Awake()
    {
        player = GameObject.Find("Player");
        playerHolder = player.GetComponent<Player>();
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void Victory()
    {
        victoryUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (playerHolder.death != false)
        {
            restartUI.SetActive(true);
        }
    }
    public static void HealthChanged(int currentHealth, int maxHealth)
    {
        if (OnPlayerHealthChanged != null)
        {
            OnPlayerHealthChanged(currentHealth, maxHealth);
        }
    }

    public static void StatsChanged()
    {
        if (OnStatsChanged != null)
        {
            OnStatsChanged();
        }
    }

    public static void PlayerLevelChanged()
    {
        if (OnPlayerLevelChange != null)
        {
            OnPlayerLevelChange();
        }
    }
}
