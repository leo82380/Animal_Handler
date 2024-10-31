using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReaderSO : ScriptableObject, BaseInput.IPlayerActions
{
    private BaseInput _baseInput;

    public event Action MouseRightClickEvent;
    public event Action MouseLeftClickEvent;
    public event Action MouseMiddleClickEvent;

    public Vector2 MousePosition { get; private set; }

    private void OnEnable()
    {
        if (_baseInput == null)
        {
            _baseInput = new BaseInput();
            _baseInput.Player.SetCallbacks(this);
        }
        _baseInput.Enable();
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        MousePosition = context.ReadValue<Vector2>();
    }

    public void OnMouseScroll(InputAction.CallbackContext context)
    {
        
    }

    public void OnMouseRadius(InputAction.CallbackContext context)
    {
        
    }

    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        
    }

    public void OnMouseRightClick(InputAction.CallbackContext context)
    {

    }

    public void OnMouseLeftClick(InputAction.CallbackContext context)
    {
        
    }

    public void OnMouseMiddleClick(InputAction.CallbackContext context)
    {
        
    }

    public void OnMousePress(InputAction.CallbackContext context)
    {
        
    }

    public void OnMouseFoward(InputAction.CallbackContext context)
    {
        
    }

    public void OnMouseBack(InputAction.CallbackContext context)
    {
        
    }
}
