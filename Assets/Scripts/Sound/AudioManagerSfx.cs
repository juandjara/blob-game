using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManagerSfx : MonoBehaviour
{
    public AudioClip[] song;
    
    public void PlayRandomSound(AudioSource audioSource)
    {
        int rand = Random.Range(0, song.Length-1);
        audioSource.PlayOneShot(song[rand]);
    }
}
