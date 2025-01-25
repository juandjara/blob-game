using UnityEngine;
using Random = UnityEngine.Random;

public class BubbleMovement : MonoBehaviour
{
 
    [SerializeField] private float _speed=0.5f;
    public Vector3 CannonRotation = new Vector3(0,0,0);

    private int _angle;

    public Rigidbody2D rb;

    private void Start()
    {
        _angle = Random.Range(-60, 60);
       BubbleMoveRandomDirectionStraight();
    }
    
   private void FixedUpdate()
    {
        //fisicas
        Debug.Log(_angle);
        
        var lDirection = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * _angle), Mathf.Cos(Mathf.Deg2Rad * _angle));

        rb.linearVelocity = (transform.up+lDirection) * _speed;
    }
   
    public void BubbleMoveRandomDirectionStraight()
    {
        
        
        //animacion
        switch (_angle)
        {
            case <-30:
                Debug.Log("animacion izquierda");
                break;
            case >30:
                Debug.Log("animacion derecha");
                break;
            default:
                Debug.Log("animación centro");
                break;
        }
        
       
    }
}
