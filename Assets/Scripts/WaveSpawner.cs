using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;

    public Transform enemyPrefab;
    //public Wave[] waves;

    public float timeBetweenWaves = 0.5f;
    private float countdown = 0.5f;

    public Text waveCountdownText;

    //public GameManager gameManager;

    private int waveIndex = 0;

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

      /*  if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        */
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
       /* PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;
        */
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        waveIndex++;
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(300, 460), 1, Random.Range(530, 720));
        Instantiate(enemyPrefab, spawnPosition, enemyPrefab.rotation);
    }

}