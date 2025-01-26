using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BubbleManager : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrfab;
    [SerializeField] private GameObject animationPrefab;
    [SerializeField] private GameObject[] spawnPoints;
    
    [SerializeField] private float spawnTime = 2f;
    private float spawnTimer;
    
    
    private Vector3 _currentEulerAngles;
    Quaternion _currentRotation;
    private Vector3 _currentPosition;
    
    private const int animAngleMin = -30;
    private const int animAngleMax = 30;

    private Animator _animator;
    
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
                CreateBubble(Random.Range(0, spawnPoints.Length ));
                spawnTimer += spawnTime;
            }
        }



        
    }
    private void CreateBubble(int pt)
    {
        /*Vector3 rotation = transform.rotation.eulerAngles;
        bubble.CannonRotation = rotation;
       */
       
        GameObject bubble= Instantiate(bubblePrfab, spawnPoints[pt].transform.position, spawnPoints[pt].transform.rotation);
        GameObject animation = Instantiate(animationPrefab, spawnPoints[pt].transform.position,
            spawnPoints[pt].transform.rotation);
        _animator = animation.GetComponent<Animator>();
        //Debug.Log("angle :) " +bubble.GetComponent<BubbleMovement>().GetAngle());
        BubbleMoveRandomDirectionStraight(bubble.GetComponent<BubbleMovement>().GetAngle());
    } 
    
    public void BubbleMoveRandomDirectionStraight(int _angle)
    {
        
        //animacion
        switch (_angle)
        {
            case < animAngleMin:
                _animator.SetInteger("Posicion",-1);
                Debug.Log("animacion izquierda");
                break;
            case > animAngleMax:
                _animator.SetInteger("Posicion",1);
                Debug.Log("animacion derecha");
                break;
            default:              
                _animator.SetInteger("Posicion",0);
                Debug.Log("animación centro");
                break;
        }
        
       
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
