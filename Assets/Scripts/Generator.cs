using UnityEngine;

public class Generator : Building
{
    //NEEDS FINISHING
    public float energyInterval = 10f;
    public int energyAmount = 25;
    private float nextEnergyTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buildingName = "Generator";
        energyCost = 50;
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextEnergyTime)
        {
            BuildingSelector selector = FindFirstObjectByType<BuildingSelector>();

            if (selector != null)
            {
                selector.AddEnergyPoints(energyAmount);
            }
            else
            {
                Debug.LogWarning("PlantSelector not found for Sunflower!");
            }

            nextEnergyTime = Time.time + energyInterval;
        }
    }
}
