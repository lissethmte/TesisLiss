using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel; // Asigna el panel del menú en el Inspector
    public Button startButton;
    public FPC fpc;
        // Asigna el botón Start en el Inspector

    void Start()
    {
        PauseGame(); // Pausar el juego al inicio
    }

    public void StartGame()
    {

        Debug.Log("Empece");
        Time.timeScale = 1f; // Reanudar el tiempo
        menuPanel.SetActive(false); // Ocultar el menú

        fpc.DesactivarMouse();
    }

    public void QuitGame()
    {
        Application.Quit(); // Cierra el juego
        Debug.Log("Juego cerrado"); // Mensaje en consola (solo visible en el editor)
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Detener el tiempo
        menuPanel.SetActive(true); // Mostrar el menú

        // Asegurar que el cursor esté visible y libre
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;

        // Asegurar que el botón Start esté seleccionado
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(startButton.gameObject);
    }
}
