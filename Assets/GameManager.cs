using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Importante: Importar TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Elements")]
    public GameObject gameOverPanel;  // Panel de Game Over
    public GameObject victoryPanel;   // Panel de Victoria
    public TextMeshProUGUI scoreText; // Texto del Score en pantalla

    private int score = 0;
    public int winningScore = 50; // Puntos necesarios para ganar
    private bool gameEnded = false; // Para evitar múltiples activaciones

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // Asegurar que los paneles están ocultos al inicio
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (victoryPanel != null) victoryPanel.SetActive(false);
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        if (gameEnded) return; // Evita sumar puntos si el juego ya terminó

        score += points;
        UpdateScoreUI();

        if (score >= winningScore)
        {
            WinGame();
        }
    }

    public void GameOver()
    {
        if (gameEnded) return;

        gameEnded = true;
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego
    }

    public void WinGame()
    {
        if (gameEnded) return;

        gameEnded = true;
        if (victoryPanel != null) victoryPanel.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Restablecer el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        else
            Debug.LogError("⚠️ ¡TextMeshPro del Score no asignado en el GameManager!");
    }
}
