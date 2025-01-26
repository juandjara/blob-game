using UnityEngine;

public class InitScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject invisMenu;
    
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame()
    {
        invisMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
