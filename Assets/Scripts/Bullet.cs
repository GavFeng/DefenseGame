using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

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
        if (collision.CompareTag("Zombie"))
        {
            ZombieHealth zombieHealth = collision.GetComponent<ZombieHealth>();
            if (zombieHealth != null)
            {
                zombieHealth.TakeDamage(10);
                Destroy(gameObject);
            }
        }
    }
}
