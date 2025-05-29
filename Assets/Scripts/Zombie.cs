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
            transform.rotation = Quaternion.identity;
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
                    Debug.Log($"Zombie dealt {damage} damage to {targetBuilding.buildingName}. Remaining health: {targetBuilding.health}");
                }
                else
                {
                    isAttacking = false;
                }
            }
        }
    }

    //isTrigger isn't active
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            isAttacking = true;
            attackTimer = 0f;
            targetBuilding = collision.GetComponent<Building>();

        }
    }
    
    //isTrigger isn't active
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag) && collision.gameObject.GetComponent<Building>() == targetBuilding)
        {
            isAttacking = false;
            targetBuilding = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag) && targetBuilding == null)
        {
            isAttacking = true;
            attackTimer = 0f;
            targetBuilding = collision.gameObject.GetComponent<Building>();
            Debug.Log($"Zombie started attacking {targetBuilding.buildingName} with health {targetBuilding.health}.");
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag) && collision.gameObject.GetComponent<Building>() == targetBuilding)
        {
            isAttacking = false;
            targetBuilding = null;
            Debug.Log("Zombie exited building collision, resuming movement.");
        }
    }

}

