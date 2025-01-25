using UnityEngine;
using Random = UnityEngine.Random;

public class BubbleMovement : MonoBehaviour
{
 
    [SerializeField] private float _speed=0.5f;
    public Vector3 CannonRotation = new Vector3(0,0,0);

    
    [SerializeField] private int shootAngleMin = -60;
    [SerializeField] private int shootAngleMax = 60;
                             
    private const int animAngleMin = -30;
    private const int animAngleMax = 30;

    private int _angle;

    public Rigidbody2D rb;

    private void Start()
    {
        _angle = Random.Range(shootAngleMin, shootAngleMax);
        Debug.Log("Bubble angle:" +_angle);
       BubbleMoveRandomDirectionStraight();
    }
    
   private void FixedUpdate()
    {
        //fisicas
        
        
        //var lDirection = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * _angle), Mathf.Cos(Mathf.Deg2Rad * _angle));
         
        rb.linearVelocity = (rotateVector(transform.up,_angle)) * _speed;
        
        //rb.linearVelocity = (transform.up+lDirection) * _speed;

    }
   
    public void BubbleMoveRandomDirectionStraight()
    {
        
        //animacion
        switch (_angle)
        {
            case < animAngleMin:
                Debug.Log("animacion izquierda");
                break;
            case > animAngleMax:
                Debug.Log("animacion derecha");
                break;
            default:
                Debug.Log("animación centro");
                break;
        }
        
       
    }
    private Vector2 rotateVector(Vector2 vector, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        return new Vector2(
            vector.x * Mathf.Cos(rad) - vector.y * Mathf.Sin(rad),
            vector.x * Mathf.Sin(rad) + vector.y * Mathf.Cos(rad)
        );
    }
}
