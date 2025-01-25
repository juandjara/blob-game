using UnityEngine;

public class CurvingBubbleMovement : MonoBehaviour
{
    [SerializeField] private float _speed=0.5f;
    public Vector3 CannonRotation = new Vector3(0,0,0);

    
    [SerializeField] private int shootAngleMin = -60;
    [SerializeField] private int shootAngleMax = 60;
                             
    private const int animAngleMin = -30;
    private const int animAngleMax = 30;

    private float _angle;
    private float _curveAngle;

    [SerializeField] private float _maxCurvingAngle = 180f;
    [SerializeField] private float _curveDecay = 3.5f;

    public Rigidbody2D rb;

    private void Start()
    {
        _angle = Random.Range(shootAngleMin, shootAngleMax);
        _curveAngle = 0;
        Debug.Log("Bubble angle:" +_angle);
        BubbleMoveRandomDirectionStraight();
    }
    
    private void FixedUpdate()
    {
        //fisicas
        
        
        //var lDirection = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * _angle), Mathf.Cos(Mathf.Deg2Rad * _angle));
        _curveAngle = expDecay(_curveAngle,  _maxCurvingAngle, _curveDecay, Time.fixedDeltaTime);
        rb.linearVelocity = rotateVector((rotateVector(transform.up,_angle)),_curveAngle) * _speed;
        
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
        if (angle != 0)
        {
            float rad = angle * Mathf.Deg2Rad;
            return new Vector2(
                vector.x * Mathf.Cos(rad) - vector.y * Mathf.Sin(rad),
                vector.x * Mathf.Sin(rad) + vector.y * Mathf.Cos(rad)
            );
        }
        else
        {
            return vector;
        }
        
    }
    float expDecay(float a, float b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }
}
