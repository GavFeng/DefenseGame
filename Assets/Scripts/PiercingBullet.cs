using UnityEngine;

public class PiercingBullet : MonoBehaviour
{
    public float speed = 10f;
    public int maxPierceCount = 3;
    private int currentPierceCount = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only count hits on zombies
        if (collision.CompareTag("Zombie"))
        {
            Health health = collision.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(10);
            }

            currentPierceCount++;

            if (currentPierceCount >= maxPierceCount)
            {
                Destroy(gameObject); // Destroy after 3 hits
            }
        }
    }
}
