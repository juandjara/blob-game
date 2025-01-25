using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    public InputReading playerInput;
    public Rigidbody2D rb;

    private float _horizontal;
    private float _vertical;
    private float _speed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnEnable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(_horizontal * _speed, _vertical * _speed);
    }

    private void OnEnable()
    {
        playerInput.EnablePlayerInput();
        playerInput.Move += OnMove;
        playerInput.OpenMenu += OnOpenMenu;
    }

    private void OnDisable()
    {
        playerInput.Move -= OnMove;
        playerInput.OpenMenu += OnOpenMenu;
    }

    public void OnMove(Vector2 movementVector)
    {
        _horizontal = movementVector.x;
        _vertical = movementVector.y;
    }

    public void OnOpenMenu()
    {
        //Hacer aqui cositas de abrir menus y movidas
        Application.Quit();
        Debug.Log("Se ha cerrao");
    }
}
