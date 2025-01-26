using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BubbleMovement : MonoBehaviour
{


    [SerializeField] private GameObject child;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    
    [SerializeField] private float _speed=0.5f;
    public Vector3 CannonRotation = new Vector3(0,0,0);

    
    [SerializeField] private int shootAngleMin = -60;
    [SerializeField] private int shootAngleMax = 60;
                             
    private const int animAngleMin = -15;
    private const int animAngleMax = 15;

    private int _angle;
    
    public float revealTime = 2f;
    private float revealTimer;
    
    public float delayTime = 1f;
    private float delayTimer;
    private bool _isMoving = false;
    
    
    private bool _isVisible = false; 
    
    public Rigidbody2D rb;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        revealTimer = revealTime;
        delayTimer = delayTime;
        _angle = Random.Range(shootAngleMin, shootAngleMax);
        switch (_angle)
        {
            case < animAngleMin:
                _angle = -25;
                break;
            case > animAngleMax:
                _angle = 25;
                break;
            default:              
                _angle = 0;
                break;
        }
        
        Debug.Log("Bubble angle:" +_angle);
        BubbleMoveRandomDirectionStraight();
        child.transform.parent = null;
        
        Destroy(child,5f);

    }

    private void FixedUpdate()
    {
        //fisicas
        if (!_isVisible)
        {
            if (revealTimer > 0)
            {
                revealTimer -= Time.fixedDeltaTime;
                if (revealTimer <= 0)
                {
                    _isVisible=true;
                    _spriteRenderer.enabled = true;
                }
            }
        }

    //var lDirection = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * _angle), Mathf.Cos(Mathf.Deg2Rad * _angle));
        if (!_isMoving)
        {
            if (delayTimer > 0)
            {
                {
                    delayTimer -= Time.fixedDeltaTime;
                    if (delayTimer <= 0)
                    {
                        _isMoving=true;
                    }
                }
            } 
        }
        else
        {
            rb.linearVelocity = (rotateVector(transform.up,_angle)) * _speed;
        }
        
        
        //rb.linearVelocity = (transform.up+lDirection) * _speed;

    }
   
    public void BubbleMoveRandomDirectionStraight()
    {
        
        //animacion
        switch (_angle)
        {
            case < animAngleMin:
                _animator.SetInteger("Posicion",1);
                Debug.Log("animacion izquierda");
                break;
            case > animAngleMax:
                _animator.SetInteger("Posicion",-1);
                Debug.Log("animacion derecha");
                break;
            default:              
                _animator.SetInteger("Posicion",0);
                Debug.Log("animación centro");
                break;
        }
        _animator.SetTrigger("Play");
        
       
    }
    private Vector2 rotateVector(Vector2 vector, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        return new Vector2(
            vector.x * Mathf.Cos(rad) - vector.y * Mathf.Sin(rad),
            vector.x * Mathf.Sin(rad) + vector.y * Mathf.Cos(rad)
        );
    }
    
    void OnTriggerEnter2D(Collider2D collider) {
        var playerParticles = collider.gameObject.GetComponent<GoopFollow>();
        if (playerParticles) {
            GameManager.instance.damagePlayer();
        } else {
            var blob = collider.gameObject.GetComponent<PickBlob>();
            if (blob) {
                Destroy(collider.gameObject);
            }
        }
        DieBubble();
    }

    void DieBubble() {
        GetComponent<SpriteRenderer>().gameObject.SetActive(false);
        GetComponent<Collider2D>().gameObject.SetActive(false);
        // play bubble explosion animation
    }
}
