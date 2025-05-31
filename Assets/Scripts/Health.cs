using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private ZombieSpawner spawner;

    void Start()
    {
        currentHealth = maxHealth;
        spawner = FindFirstObjectByType<ZombieSpawner>();
        if (spawner == null)
        {
            Debug.LogWarning("No ZombieSpawner found in scene!");
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            if (spawner != null)
            {
               spawner.OnZombieDestroyed();
               Debug.Log($"Working");
            }
           
            Destroy(gameObject);
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}

