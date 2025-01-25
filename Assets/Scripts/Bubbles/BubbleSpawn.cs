using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BubbleSpawn : MonoBehaviour
{
    [SerializeField] private int waitingSeconds;
    [SerializeField] private BubbleMovement bubble;
    [SerializeField] private int Inverse;
    
    private Vector3 _currentEulerAngles;
    Quaternion _currentRotation;
    private Vector3 _currentPosition;
    IEnumerator CreateBubble()
    {
        Inverse = bubble.Inverse; 
        Vector3 rotation = transform.rotation.eulerAngles;
        bubble.CannonRotation = rotation;
        Debug.Log("bubble angle"+bubble.CannonRotation);
       
        Instantiate(bubble, gameObject.transform.position, transform.rotation);
        yield return new WaitForSeconds(waitingSeconds);
    } 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void SpawnBubble()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateBubble());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
