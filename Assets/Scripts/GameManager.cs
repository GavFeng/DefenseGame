using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI loseText;
    public GameObject gameOverPanel;

    private bool gameEnded = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        loseText.gameObject.SetActive(false);
    }

    public void LoseGame()
    {
        if (gameEnded) return;
        gameEnded = true;
        Debug.Log("YOU LOSE!");

        loseText.gameObject.SetActive(true);
        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}

