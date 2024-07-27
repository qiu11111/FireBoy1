using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName ="PlayerInput")]
public class PlayerInput : ScriptableObject, InputActions.IPlayerActions
{
    private InputActions inputActions;

    public UnityAction<Vector2> onMove;
    public UnityAction disMove;
    public UnityAction onJump;
    public UnityAction onTrans;


    private void OnEnable()
    {
        inputActions = new InputActions();
        inputActions.Player.SetCallbacks(this);
    }

    public void startPlayerInput()
    {
        inputActions.Player.Enable();
    }

    public void OnWalk(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onMove?.Invoke(context.ReadValue<Vector2>());
        }
        if (context.canceled)
        {
            disMove?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            onJump?.Invoke();
    }

    public void OnIce(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onTrans?.Invoke();
        }
    }
}
