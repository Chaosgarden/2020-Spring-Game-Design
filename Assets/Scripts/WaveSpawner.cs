using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState
    {
        SPAWNING,WAITING,COUNTING
    };

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;
    
    public SpawnState state = SpawnState.COUNTING;
    private int waveIndex = 0;

    void Update()
    {
        Debug.Log(waves.Length);
        if(state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                
            }
            else
            {
                return;
            }
        }
        if (waveIndex == 0)
        {
            
        }
        if (waveIndex == waves.Length)
        {
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                return;
            }
        }
        else
        {
            countdown -= Time.deltaTime;

            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        }
       // Debug.Log(string.Format("{0:00.00}", countdown));
    }
    bool EnemyIsAlive()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            return false;
        }
        return true;
    }
    void WaveCompleted()
    {
        waveIndex++;
        state = SpawnState.COUNTING;
        countdown = timeBetweenWaves;
    }
    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;
        state = SpawnState.SPAWNING;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f);
        }
        waveIndex++;
        state = SpawnState.WAITING;
    }

    void SpawnEnemy(GameObject enemy)
    {
        if (spawnPoint != null)
        {
            Instantiate(enemy, spawnPoint.position, enemy.transform.rotation);
        }
        else
        {
            Vector3 spawnPosition = new Vector3(Random.Range(300, 460), 1, Random.Range(530, 720));
            Instantiate(enemy, spawnPosition, enemy.transform.rotation);
        }
    }

}