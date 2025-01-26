using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BubbleManager : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrfab;
    [SerializeField] private GameObject[] spawnPoints;
    
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private float killTime = 15f;
    private float spawnTimer;
    
    
    private Vector3 _currentEulerAngles;
    Quaternion _currentRotation;
    private Vector3 _currentPosition;
    
    
    
    void Start()
    {
        spawnTimer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
       if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                CreateBubble(Random.Range(0, spawnPoints.Length-1));

                spawnTimer += spawnTime;
            }
        }



        
    }
    private void CreateBubble(int pt)
    {
        /*Vector3 rotation = transform.rotation.eulerAngles;
        bubble.CannonRotation = rotation;
       */
       
        var bubble = Instantiate(bubblePrfab, spawnPoints[pt].transform.position, spawnPoints[pt].transform.rotation);
        Destroy(bubble, killTime);
    } 
    
    
    public void setBubbleFrecuency(float time)
    {
        spawnTime = time;
    }
    
    public float getBubbleFrecuency()
    {
        return spawnTime;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
/*
    public void SpawnBubble()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateBubble());
    }
    */
    
}
