using System;
using UnityEngine;

public class OuterBubble : MonoBehaviour
{
    public SpriteRenderer bubbleImg;
    public SpriteRenderer bubbleOut;
    public CameraFollow cam;
    
    [SerializeField] private Animator _animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (GameManager.instance.isWinCondition) {
            cam.unlockCamera();
            bubbleOut.enabled = false;
            bubbleImg.enabled = false; 
            _animator.SetTrigger("Break");
            return;
        }

        var point = collider.ClosestPoint(transform.position);
        var player = collider.gameObject.GetComponent<PlayerManager>();
        if (player) {
            // player.toggleSpeedDampening(false);
            var rb = player.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(point * -1000, ForceMode2D.Force);
        }
    }
}
