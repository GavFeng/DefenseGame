using UnityEngine;

public class TurretTemp : Building
{
    public float fireRate = 1f;
    public GameObject bulletPrefab; 
    private float nextFireTime;
    public float upOffset = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buildingName = "Turret";
        energyCost = 50;
        health = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Instantiate(bulletPrefab, transform.position + Vector3.right * 0.5f  + Vector3.up * upOffset, Quaternion.identity);
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
