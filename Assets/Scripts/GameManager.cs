using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float gameDuration = 120f;
    private float timer;

    public TextMeshProUGUI resultText;
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
        timer = gameDuration;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            WinGame();
        }
    }

    public void LoseGame()
    {
        if (gameEnded) return;
        gameEnded = true;
        Debug.Log("YOU LOSE!");
        resultText.text = "YOU LOSE";
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        if (gameEnded) return;
        gameEnded = true;
        resultText.text = "YOU WIN";
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}

