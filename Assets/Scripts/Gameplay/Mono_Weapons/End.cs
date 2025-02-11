using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class EndLevel : MonoBehaviour
{
    // M�todo que se llama cuando el jugador colisiona con el "end"
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Si el jugador colisiona con el collider llamado "end", se carga la escena del men� principal
            SceneManager.LoadScene("MenuInicial");  // Aseg�rate de que "MainMenu" sea el nombre de tu escena de men�
        }
    }
}

