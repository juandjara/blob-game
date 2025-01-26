using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    public InputReading playerInput;

    private Rigidbody2D _rigidbody2D;

    public float MAX_SPEED = 5f;

    private float _horizontal;
    private float _vertical;
    private float _speed = 5f;
    private float _minSpeed = 0.5f;
    public float _speedDecay = 16f;
    private bool _isDampening = false;

    public GameObject initScrn;

    public void toggleSpeedDampening(bool flag) {
        _isDampening = flag;
    }
    
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); // Start is called once before the first execution of Update after the MonoBehaviour is created
    }

    void Start()
    {
        OnEnable();
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var x = _horizontal * _speed;
        var y = _vertical * _speed;
        _rigidbody2D.linearVelocity = new Vector2(x, y);

        if (_isDampening) {
            var center = new Vector2(0, 0);
            var direction = (center - new Vector2(transform.position.x, transform.position.y)).normalized;
            _rigidbody2D.AddForce(direction * 5f, ForceMode2D.Impulse);
        }
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
        PauseMenu.PausePressed = true;
        //Application.Quit();
        Debug.Log("Se ha cerrao");
    }
    /*
    public void OnStartGame()
    {
        if (!_isStarted)
        {
            _isStarted = true;
            initScrn.SetActive(false);
            Time.timeScale = 1f;
        }
    } 
    */

    float expDecay(float a, float b, float decay, float dt)
    {
        return b + (a - b) * Mathf.Exp(-decay * dt);
    }
}
