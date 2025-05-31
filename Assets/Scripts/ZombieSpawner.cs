using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GridManager gridManager;


    [Header("Zombie Prefabs")]
    public GameObject zombiePrefab;
    public GameObject acidZombiePrefab;
    public GameObject armoredZombiePrefab;

    [Header("Spawn Intervals (Seconds)")]
    public float spawnInterval = 3f;
    public int maxTotalZombies = 10;
    public float waveInterval = 30f;

    [Header("Spawn Weights (Sum to 100)")]
    public int regularZombieWeight = 60; 
    public int acidZombieWeight = 30;
    public int armoredZombieWeight = 10;

    private float spawnTimer;
    private float waveTimer;
    private int totalZombieCount = 0;
    private int wave = 1;
    private int zombiesPerSpawn = 1;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        waveTimer += Time.deltaTime;

        // Check for new wave
        if (waveTimer >= waveInterval)
        {
            wave++;
            zombiesPerSpawn = Mathf.Min(wave, maxTotalZombies / 2); // Cap spawn count to avoid exceeding maxTotalZombies
            waveTimer = 0f;
            Debug.Log($"Wave {wave} started. Spawning {zombiesPerSpawn} zombies per interval. Max zombies: {maxTotalZombies}");
        }

        // Spawn zombies
        if (spawnTimer >= spawnInterval && totalZombieCount < maxTotalZombies)
        {
            SpawnZombies();
            spawnTimer = 0f;
        }
    }

    void SpawnZombies()
    {
        if (zombiePrefab == null && acidZombiePrefab == null && armoredZombiePrefab == null)
        {
            Debug.LogWarning("No valid zombie prefabs assigned!");
            return;
        }

        int zombiesToSpawn = Mathf.Min(zombiesPerSpawn, maxTotalZombies - totalZombieCount); // Limit by remaining capacity

        for (int i = 0; i < zombiesToSpawn; i++)
        {
            int randomValue = Random.Range(0, 100);
            GameObject zombieToSpawn = null;

            if (randomValue < regularZombieWeight && zombiePrefab != null)
            {
                zombieToSpawn = zombiePrefab;
            }
            else if (randomValue < regularZombieWeight + acidZombieWeight && acidZombiePrefab != null)
            {
                zombieToSpawn = acidZombiePrefab;
            }
            else if (armoredZombiePrefab != null)
            {
                zombieToSpawn = armoredZombiePrefab;
            }

            if (zombieToSpawn != null)
            {
                int row = Random.Range(0, gridManager.rows);
                int col = gridManager.columns - 1;
                Vector3 spawnPos = gridManager.gridOrigin + new Vector2(col * gridManager.cellSize, row * gridManager.cellSize);
                Instantiate(zombieToSpawn, spawnPos, Quaternion.identity);
                totalZombieCount++;
                Debug.Log($"Spawned {zombieToSpawn.name}. Total zombies: {totalZombieCount}");
            }
        }
    }

    public void OnZombieDestroyed()
    {
        if (totalZombieCount > 0)
        {
            totalZombieCount--;
        }
    }
}

