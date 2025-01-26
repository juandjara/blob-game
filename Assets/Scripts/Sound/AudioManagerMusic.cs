using UnityEngine;

public class AudioManagerMusic : MonoBehaviour
{
    public AudioClip[] song;
    public AudioSource audioSource;
    private int i = 0;
    public float timer = 0;
    [SerializeField] private float secondsToChangeSong = 30;
    private float seconds;
    public void NextSong()
    {
        i++;
        PlaySong();
    }
    private void PlaySong()
    {
        audioSource.clip = song[i];
        audioSource.Play();

    }
    
    void Update()
    {
        if (seconds < secondsToChangeSong)
        {
            timer += Time.deltaTime;
            seconds = timer % 60;
            Debug.Log("seconds"+seconds);
        }else NextSong();
    }
}
