using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 5;
    public int columns = 9;
    public float cellSize = 1f;
    public Vector2 gridOrigin;
    private bool[,] filledCells;
    private Vector3[,] cellPositions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        filledCells = new bool[rows, columns];
        cellPositions = new Vector3[rows, columns];
        CalculateCellPositions();
    }


    // Update is called once per frame
    void Update()
    {

    }



    void CalculateCellPositions()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                cellPositions[row, col] = gridOrigin + new Vector2(col * cellSize, row * cellSize);
            }
        }
    }


    public Vector3 NearestCellPosition(Vector2 worldPos)
    {
        Vector2 localPos = worldPos - gridOrigin;
        int col = Mathf.Clamp(Mathf.RoundToInt(localPos.x / cellSize), 0, columns - 1);
        int row = Mathf.Clamp(Mathf.RoundToInt(localPos.y / cellSize), 0, rows - 1);
        return cellPositions[row, col];
    }

    public bool IsCellFilled(int row, int col)
    {
        return filledCells[row, col];
    }

    public void OccupyCell(int row, int col, bool occupy = true)
    {
        filledCells[row, col] = occupy;
    }

    public Vector2Int GetCellIndex(Vector2 worldPos)
    {
        Vector2 localPos = worldPos - gridOrigin;
        int col = Mathf.Clamp(Mathf.RoundToInt(localPos.x / cellSize), 0, columns - 1);
        int row = Mathf.Clamp(Mathf.RoundToInt(localPos.y / cellSize), 0, rows - 1);
        return new Vector2Int(row, col);
    }

}
