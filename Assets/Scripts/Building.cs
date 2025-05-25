using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public int energyCost;
    public float health;
    public string buildingName;

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GridManager gridManager = FindFirstObjectByType<GridManager>();
            if (gridManager != null)
            {
                Vector2Int cellIndex = gridManager.GetCellIndex(transform.position);
                gridManager.OccupyCell(cellIndex.x, cellIndex.y, false);
            }
            Destroy(gameObject);
        }
    }

}