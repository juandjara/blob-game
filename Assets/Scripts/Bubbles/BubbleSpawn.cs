using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BubbleSpawn : MonoBehaviour
{
    [SerializeField] private int waitingSeconds;
    [SerializeField] private BubbleMovement bubble;
    
    private Vector3 _currentEulerAngles;
    Quaternion _currentRotation;
    private Vector3 _currentPosition;
    IEnumerator CreateBubble()
    {
        /*Vector3 rotation = transform.rotation.eulerAngles;
        bubble.CannonRotation = rotation;
       */
       
        Instantiate(bubble, gameObject.transform.position, transform.rotation);
        yield return new WaitForSeconds(waitingSeconds);
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
