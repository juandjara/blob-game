using UnityEngine;

public class BlobSpawner : MonoBehaviour
{
    public GameObject blobPrefab;
    public float bubbleRadius = 5f;
    public float bubbleOffset = 0.5f;
    private float spawnRadius;
    private bool isSpawned;

    public GameObject bubbleCenter;
    public float spawnTime = 2f;
    private float spawnTimer;
    private GameObject spawnPoint;
    
    public static bool suficientBlobs = false;
    
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = spawnTime;
        spawnPoint = new GameObject();
    }

    void Awake()
    {
        suficientBlobs = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!suficientBlobs)
        {
            spawnRadius = bubbleRadius - bubbleOffset;

            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0)
                {
                    SpawnBlob();

                    spawnTimer += spawnTime;
                }
            }
        }
    }

    private void SpawnBlob()
    {
        isSpawned = false;
        float spawnX = Random.Range(-spawnRadius, spawnRadius);
        float spawnY = Random.Range(-spawnRadius, spawnRadius);
        spawnPoint.transform.position = new Vector2(spawnX, spawnY);
        while (!isSpawned)
        {
            if (Vector2.Distance(spawnPoint.transform.position, bubbleCenter.transform.position) <= spawnRadius)
            {
                Instantiate(blobPrefab, spawnPoint.transform.position, Quaternion.identity);
                isSpawned = true;
            }
            else
            {
                spawnX = Random.Range(-spawnRadius, spawnRadius);
                spawnY = Random.Range(-spawnRadius, spawnRadius);
                spawnPoint.transform.position = new Vector2(spawnX, spawnY);
            }
        }
    }

    public void startSpawner()
    {
        suficientBlobs = false;
    }
    public void stopSpawner()
    {
        suficientBlobs = true;
    }

    public void setBlobFrecuency(float time)
    {
        spawnTime = time;
    }
    
    public float getBlobFrecuency()
    {
        return spawnTime;
    }
    
}
