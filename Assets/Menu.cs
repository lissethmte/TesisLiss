using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel; // Asigna el panel del menú en el Inspector
    public Button startButton;
    public FPC fpc;

    public GameObject uiElementsPanel; // Panel que contiene los demás elementos de UI
    public GameObject anotherPanel;    // Segundo panel que también queremos ocultar

    void Start()
    {
        PauseGame(); // Pausar el juego al inicio
    }

    public void StartGame()
    {
        Debug.Log("Empece");
        Time.timeScale = 1f; // Reanudar el tiempo
        menuPanel.SetActive(false); // Ocultar el menú
        uiElementsPanel.SetActive(true); // Mostrar los demás elementos de UI
        anotherPanel.SetActive(true);   // Mostrar el segundo panel

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
        uiElementsPanel.SetActive(false); // Ocultar los demás elementos de UI
        anotherPanel.SetActive(false);    // Ocultar el segundo panel

        // Asegurar que el cursor esté visible y libre
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;

        // Asegurar que el botón Start esté seleccionado
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(startButton.gameObject);
    }
}

