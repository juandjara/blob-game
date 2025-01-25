using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public int blobsNeeded = 100;
    private int currentBlobs = 0;

    public GameObject[] levels;

    public GameObject goop;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        } 
    }

    public void StartLevel(int index) {
        for (int i = 0; i < levels.Length; i++) {
            levels[index].SetActive(i == index);
        }
    }

    public void resetBlobs() {}

    public void addBlob() {}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
