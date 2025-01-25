using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    public InputReading playerInput;
    public Rigidbody2D rb;

    private float horizontal;
    private float vertical;
    private float speed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void OnEnable()
    {
        playerInput.EnablePlayerInput();
        playerInput.Move += OnMove;
    }

    private void OnDisable()
    {
        playerInput.Move -= OnMove;
    }

    private void OnMove(Vector2 movementVector)
    {
        horizontal = movementVector.x;
        vertical = movementVector.y;
    }
}
