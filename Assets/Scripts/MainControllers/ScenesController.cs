using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isGamePaused = false;

    void Start()
    {
       
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
          
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
          
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }

    public void GoToMainMenu()
    {
       
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }
}
