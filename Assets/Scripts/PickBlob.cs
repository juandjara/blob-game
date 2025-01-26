using UnityEngine;

public class PickBlob : MonoBehaviour
{
    private AudioSource _audioSource;
    private AudioManagerSfx _audioManagerSfx;
    void Awake()
    {
        _audioManagerSfx = (AudioManagerSfx)FindObjectOfType(typeof(AudioManagerSfx));
        _audioSource = (AudioSource)FindFirstObjectByType(typeof(AudioSource));

        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.gameObject.GetComponent<PlayerManager>();
        if (player) {
            GameManager.instance.addBlob();
            _audioManagerSfx.PlayRandomSound(_audioSource);
            Destroy(gameObject);
        }
    }
}
