using UnityEngine;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "BuildingData")]
public class BuildingData : ScriptableObject
{
        public string buildingName;
        public GameObject buildingPrefab;
        public GameObject previewPrefab;
        public int energyCost;
}
