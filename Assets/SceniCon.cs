using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceniCon : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public string gameSceneName = "Test_LlvFinal";

    void Start()
    {
     
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
       
        SceneManager.LoadScene(gameSceneName);
    }

    void QuitGame()
    {
     
        Application.Quit();
        Debug.Log("Juego cerrado");
    }
}
