using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GridManager gridManager;

    [Header("Zombie Prefabs")]
    public GameObject zombiePrefab;
    public GameObject acidZombiePrefab;
    public GameObject armoredZombiePrefab;

    [Header("Spawn Intervals (Seconds)")]
    public float zombieSpawnInterval = 2f;
    public float acidZombieSpawnInterval = 5f;
    public float armoredZombieSpawnInterval = 8f;

    [Header("Spawn Limits")]
    public int zombieMaxCount = 10;
    public int acidMaxCount = 5;
    public int armoredMaxCount = 3;

    private float zombieTimer;
    private float acidZombieTimer;
    private float armoredZombieTimer;

    private int zombieCurrentCount = 0;
    private int acidCurrentCount = 0;
    private int armoredCurrentCount = 0;

    void Update()
    {
        zombieTimer += Time.deltaTime;
        acidZombieTimer += Time.deltaTime;
        armoredZombieTimer += Time.deltaTime;

        if (zombieTimer >= zombieSpawnInterval && zombieCurrentCount < zombieMaxCount)
        {
            Spawn(zombiePrefab);
            zombieCurrentCount++;

            zombieTimer = 0f;
        }

        if (acidZombieTimer >= acidZombieSpawnInterval && acidCurrentCount < acidMaxCount)
        {
            Spawn(acidZombiePrefab);
            acidCurrentCount++;

            acidZombieTimer = 0f;
        }

        if (armoredZombieTimer >= armoredZombieSpawnInterval && armoredCurrentCount < armoredMaxCount)
        {
            Spawn(armoredZombiePrefab);
            armoredCurrentCount++;

            armoredZombieTimer = 0f;
        }
    }

    void Spawn(GameObject zombieType)
    {
        if (zombieType == null)
            return;

        int row = Random.Range(0, gridManager.rows);
        int col = gridManager.columns - 1;

        Vector3 spawnPos = gridManager.gridOrigin + new Vector2(col * gridManager.cellSize, row * gridManager.cellSize);
        Instantiate(zombieType, spawnPos, Quaternion.identity);
    }
}

