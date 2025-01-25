using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReading : ScriptableObject, InputSystem_Actions.IPlayerActions
{

    public event UnityAction<Vector2> Move = delegate { };

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

    public void OnLook(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
    #endregion
}
