using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed = 2f;
    public string targetTag = "Building";
    public int damage = 20;
    public float attackInterval = 1f;

    private Building targetBuilding;
    private bool isAttacking = false;
    private float attackTimer;

    void Update()
    {
        if (!isAttacking)
        {
            // Move left toward the target
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            // Attack over time
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackInterval)
            {
                attackTimer = 0f;

                if (targetBuilding != null)
                {
                    targetBuilding.TakeDamage(damage);
                }
                else
                {
                    Destroy(gameObject); // Stop attacking if the building is already gone
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            targetBuilding = collision.GetComponent<Building>();
            if (targetBuilding != null)
            {
                isAttacking = true;
                attackTimer = 0f;
            }
        }
    }
}

