using UnityEngine;

public class AudioManagerPop : MonoBehaviour
{
    public AudioClip[] song;
    public AudioSource audioSource;

    public bool bigBubble = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayRandomSoundPop()
    {
        int rand;
        if(bigBubble) rand = Random.Range(0, 2);
        else rand = Random.Range(3, song.Length-1);
        audioSource.PlayOneShot(song[rand]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
