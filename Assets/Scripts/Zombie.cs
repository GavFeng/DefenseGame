using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed = 2f;
    public string targetTag = "Building";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            BuildingHealth buildingHealth = collision.GetComponent<BuildingHealth>();
            if (buildingHealth != null)
            {
                buildingHealth.TakeDamage(20);
            }
            Destroy(gameObject);
      }
    }
}
