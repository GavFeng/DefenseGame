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
        Zombie zombie = collision.GetComponent<Zombie>();
        if (zombie != null)
        {
            zombie.TakeDamage(10); // Already does health update, bar, destroy
        }

        Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    //{
        //if (collision.CompareTag("Zombie"))
        //{
           // Health health = collision.GetComponent<Health>();
           // if (health != null)
          //  {
                // Apply damage
              //  health.TakeDamage(10);
         //   }

          //  Destroy(gameObject);
     //   }
    //}
}
