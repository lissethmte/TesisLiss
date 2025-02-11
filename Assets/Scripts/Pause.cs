using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Referencia al menú de pausa en la escena
    private bool isPaused = false;

    void Update()
    {
        // Verifica si se presiona la tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Si está en pausa, reanuda el juego
            }
            else
            {
                PauseGame(); // Si no está en pausa, pausa el juego
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true); // Activa el menú de pausa
        Time.timeScale = 0f; // Detiene el tiempo del juego
        Cursor.lockState = CursorLockMode.None; // Libera el cursor
        Cursor.visible = true; // Hace visible el cursor
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false); // Desactiva el menú de pausa
        Time.timeScale = 1f; // Restaura el tiempo del juego
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
        Cursor.visible = false; // Oculta el cursor
    }

    public void ReturnToMenu(string MenuInicial)
    {
        Time.timeScale = 1f; // Asegúrate de restaurar el tiempo del juego
        SceneManager.LoadScene(MenuInicial); // Carga la escena del menú principal
    }
}
