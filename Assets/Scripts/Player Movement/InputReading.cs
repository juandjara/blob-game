using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReading : ScriptableObject, InputSystem_Actions.IPlayerActions
{

    public event UnityAction<Vector2> Move = delegate { };
    public event UnityAction OpenMenu = delegate { }; 
    public event UnityAction StartGame = delegate { }; 

    private InputSystem_Actions _gameInput;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new InputSystem_Actions();
            _gameInput.Player.SetCallbacks(this);
        }
    }

    private void OnDisable()
    {
        DisableALlInput();
    }

    public void EnablePlayerInput()
    {
        _gameInput.Player.Enable();
    }

    private void DisableALlInput()
    {
        _gameInput.Player.Disable();
    }

    #region GAMEPLAY

    public void OnMove(InputAction.CallbackContext context)
    {
        Move.Invoke(context.ReadValue<Vector2>());
    }

    public void OnOpenMenu(InputAction.CallbackContext context)
    {
        if(context.performed) OpenMenu.Invoke();
    }
    /*
    public void OnStartGame(InputAction.CallbackContext context)
    {
        if(context.performed) StartGame.Invoke();
    }
    */
  
    #endregion
}
