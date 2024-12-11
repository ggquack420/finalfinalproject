using System.Collections;
using UnityEngine;


//Spawns enemies in waves and tracks their count.

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyPrefab;    //Enemy prefab
    public Transform[] spawnPoints;   //Spawn locations
    public int initialEnemies = 5;    //Enemies in the first wave
    public float timeBetweenWaves = 5f; //Delay between waves

    public int CurrentWave { get; private set; } //Public property for wave tracking

    private int enemiesToSpawn;  //Number of enemies in the current wave
    private int enemiesAlive;    //Currently alive enemies

    void Start()
    {
        CurrentWave = 0;
        StartNextWave();
    }

 
    //Initiates the next wave.
    void StartNextWave()
    {
        CurrentWave++;
        enemiesToSpawn = initialEnemies + (CurrentWave * 2);
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f); //Delay between spawns
        }
    }


    //Spawns a single enemy.

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        //Assign the player to the EnemyAI script of the spawned zombie
        EnemyAI enemyAI = spawnedEnemy.GetComponent<EnemyAI>();
        if (enemyAI != null)
        {
            enemyAI.player = FindObjectOfType<PlayerController>().transform; //Find the player and assign it
        }

        enemiesAlive++;
    }


    //Updates the spawner when an enemy is killed.

    public void EnemyKilled()
    {
        enemiesAlive--;
        if (enemiesAlive <= 0)
        {
            Invoke(nameof(StartNextWave), timeBetweenWaves);
        }
    }
}