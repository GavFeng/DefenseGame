using UnityEngine;

public class LoseZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.name);
        
        if (other.CompareTag("Zombie"))
        {
            Debug.Log("Zombie entered lose zone!");
            GameManager.Instance.LoseGame();
        }
    }
}
