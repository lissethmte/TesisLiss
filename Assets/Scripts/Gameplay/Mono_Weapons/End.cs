using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class EndLevel : MonoBehaviour
{
    // Método que se llama cuando el jugador colisiona con el "end"
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Si el jugador colisiona con el collider llamado "end", se carga la escena del menú principal
            SceneManager.LoadScene("MenuInicial");  // Asegúrate de que "MainMenu" sea el nombre de tu escena de menú
        }
    }
}

