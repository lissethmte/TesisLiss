using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Asegúrate de incluir esto para usar TextMesh Pro
using UnityEngine.SceneManagement;

public class ZoneTimer : MonoBehaviour
{
    public float countdownTime = 60f; // Tiempo en segundos (1 minuto)
    public TextMeshProUGUI timerText; // Texto para mostrar el tiempo con TextMeshPro
    public TextMeshProUGUI messageText; // Texto para mostrar el mensaje de fin

    private bool timerActive = false;
    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
        UpdateTimerUI();
        messageText.gameObject.SetActive(false);  // Asegura que el mensaje esté oculto al inicio
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();

            if (currentTime <= 0)
            {
                timerActive = false;
                currentTime = 0;
                UpdateTimerUI();
                EndTimer(); // Llamar cuando el tiempo se acabe
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !timerActive) // Asegura que solo se active una vez
        {
            StartTimer();
        }
    }

    void StartTimer()
    {
        timerActive = true;
        messageText.gameObject.SetActive(false);  // Asegura que el mensaje no aparezca al inicio
        Debug.Log("¡Timer iniciado!");
    }

    void EndTimer()
    {
        messageText.gameObject.SetActive(true);  // Mostrar el mensaje cuando el tiempo se acabe
        messageText.text = "¡Se acabó el tiempo!";

        Debug.Log("¡Tiempo terminado!");

        // Reiniciar la escena después de 3 segundos
        Invoke("RestartGame", 3f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Recarga la escena actual
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Tiempo: " + Mathf.Ceil(currentTime).ToString();
        }
    }
}
