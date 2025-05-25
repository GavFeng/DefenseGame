using UnityEngine;

public class Wall : Building
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buildingName = "Wall";
        energyCost = 50;
        health = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
