using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMGNT: MonoBehaviour
{
    public void LoadGameplay()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
