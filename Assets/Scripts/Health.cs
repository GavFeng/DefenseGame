using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}

