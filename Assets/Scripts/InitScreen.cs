using UnityEngine;

public class InitScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject invisMenu;
    public AudioManagerMusic audioManagerMusic;
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
        audioManagerMusic.NextSong();
        invisMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
