using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthBar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (healthBar != null)
            healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
