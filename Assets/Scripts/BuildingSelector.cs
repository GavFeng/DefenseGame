using UnityEngine;
using UnityEngine.UI; // For Image
using TMPro; // For TextMeshProUGUI

public class BuildingSelector : MonoBehaviour
{
    public BuildingData[] buildingTypes = new BuildingData[5]; 
    public TextMeshProUGUI energyPointsText;
    public Image[] buildingImages = new Image[5];
    public TextMeshProUGUI[] buildingLabels = new TextMeshProUGUI[5];
    private GameObject previewInstance;
    private BuildingData selectedBuilding;
    private GridManager gridManager;
    private bool isDragging;
    private bool dragStartedThisFrame;
    private int energyPoints = 200;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        gridManager = FindFirstObjectByType<GridManager>();
        if (gridManager == null)
        {
            Debug.LogError("GridManager not found in scene!");
        }
        if (buildingTypes.Length != 5 || buildingImages.Length != 5 || buildingLabels.Length != 5)
        {
            Debug.LogError("BuildingSelector requires exactly 5 building types, images, and labels!");
        }

        // Set up image labels
        for (int i = 0; i < 5; i++)
        {
            buildingLabels[i].text = $"{buildingTypes[i].buildingName}\n{buildingTypes[i].energyCost}";
        }
        UpdateEnergyPointsUI();
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 snapPos = gridManager.NearestCellPosition(mousePos);
            previewInstance.transform.position = snapPos;

            Vector2Int cellIndex = gridManager.GetCellIndex(mousePos);
            bool isValid = !gridManager.IsCellFilled(cellIndex.x, cellIndex.y);
            SpriteRenderer renderer = previewInstance.GetComponent<SpriteRenderer>();
            renderer.color = isValid ? new Color(1, 1, 1, 0.5f) : new Color(1, 0, 0, 0.5f);

            if (Input.GetMouseButtonUp(0) && !dragStartedThisFrame && isValid)
            {
                PlaceBuilding(snapPos, cellIndex);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                CancelPlacement();
            }
        }

        if (dragStartedThisFrame)
        {
            dragStartedThisFrame = false;
        }
    }

    public void StartDragging(int buildingIndex)
    {
        if (buildingIndex < 0 || buildingIndex >= 5) return;

        selectedBuilding = buildingTypes[buildingIndex];
        if (energyPoints >= selectedBuilding.energyCost)
        {
            if (previewInstance != null)
            {
                Destroy(previewInstance);
            }
            isDragging = true;
            dragStartedThisFrame = true;
            previewInstance = Instantiate(selectedBuilding.previewPrefab);
        }
        else
        {
            Debug.Log($"Cannot place {selectedBuilding.buildingName}: Not enough Energy!");
        }
    }

    void CancelPlacement()
    {
        Destroy(previewInstance);
        isDragging = false;
        selectedBuilding = null;
    }

    void PlaceBuilding(Vector3 position, Vector2Int cellIndex)
    {
        Instantiate(selectedBuilding.buildingPrefab, position, Quaternion.identity);
        gridManager.OccupyCell(cellIndex.x, cellIndex.y);
        energyPoints -= selectedBuilding.energyCost;
        Destroy(previewInstance);
        isDragging = false;
        selectedBuilding = null;
        UpdateEnergyPointsUI();
    }

    void UpdateEnergyPointsUI()
    {
        energyPointsText.text = $"Energy: {energyPoints}";
        for (int i = 0; i < 5; i++)
        {
            bool canAfford = energyPoints >= buildingTypes[i].energyCost;
            buildingImages[i].color = canAfford ? Color.white : new Color(0.5f, 0.5f, 0.5f, 0.5f); // Gray out if not enough energy
        }
    }

    public void AddEnergyPoints(int amount)
    {
        energyPoints += amount;
        UpdateEnergyPointsUI();
    }

    public int GetEnergyPoints()
    {
        return energyPoints;
    }

    public int GetBuildingCost(int buildingIndex)
    {
        if (buildingIndex < 0 || buildingIndex >= 5) return int.MaxValue;
        return buildingTypes[buildingIndex].energyCost;
    }
}