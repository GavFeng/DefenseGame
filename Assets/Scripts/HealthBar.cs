using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthSlider; // Drag your Slider component here
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider == null)
        {
            healthSlider = GetComponentInChildren<Slider>();
        }

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public bool IsDead()
{
    return currentHealth <= 0;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
