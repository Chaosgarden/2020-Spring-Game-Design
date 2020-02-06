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
    public GameObject clearedWavesHolder;
    WaveSpawner clearedWaves;
    void Awake()
    {
        player = GameObject.Find("Player");
        playerHolder = player.GetComponent<Player>();
        clearedWaves = clearedWavesHolder.GetComponent<WaveSpawner>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerHolder.death != false)
        {
            restartUI.SetActive(true);
        }
        if (clearedWaves.cleared != false)
        {
            victoryUI.SetActive(true);
            restartUI.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void Victory()
    {
        victoryUI.SetActive(true);
    }
}
