using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMGNT : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void LoadGameplay()
    {
        SceneManager.LoadScene(1);
    }
    void LoadGMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    void QuitGame()
    {
        Application.Quit();
    }
}
