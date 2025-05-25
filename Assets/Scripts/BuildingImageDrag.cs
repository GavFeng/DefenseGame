using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingImageDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public BuildingSelector buildingSelector;
    public int buildingIndex; 
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("BuildingImageDrag requires an Image component!");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (buildingSelector == null) return;

        // Only start dragging if there’s enough energy
        if (buildingSelector.GetEnergyPoints() >= buildingSelector.GetBuildingCost(buildingIndex))
        {
            buildingSelector.StartDragging(buildingIndex);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Dragging is handled by BuildingSelector.Update
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Placement is handled by BuildingSelector.Update
    }
}
