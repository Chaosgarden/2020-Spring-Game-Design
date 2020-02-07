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
    public GameObject statsUI;
    public GameObject waitUI;
    public static UIManager Instance { get; set; }

    public delegate void PlayerHealthEventHandler(int currentHealth, int maxHealth);
    public static event PlayerHealthEventHandler OnPlayerHealthChanged;

    public delegate void StatsEventHandler();
    public static event StatsEventHandler OnStatsChanged;

    public delegate void PlayerStateHandler();
    public static event PlayerStateHandler OnPlayerDeath;

    public delegate void PlayerLevelEventHandler();
    public static event PlayerLevelEventHandler OnPlayerLevelChange;

    public static bool playerState = false;
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
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
    public void Defeat()
    {
        restartUI.SetActive(true);
    }
    public void WaitForWave(bool active)
    {
        if (active == true)
        {
            waitUI.SetActive(true);
        }
        if (active == false)
        {
            waitUI.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            if (statsUI.activeSelf != false)
            {
                statsUI.SetActive(false);
            }
            else
            {
                statsUI.SetActive(true);
            }
        }
    }

    public static void HealthChanged(int currentHealth, int maxHealth)
    {
        if (OnPlayerHealthChanged != null)
        {
            OnPlayerHealthChanged(currentHealth, maxHealth);
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
