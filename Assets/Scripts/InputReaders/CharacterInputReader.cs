using UnityEngine;
using UnityEngine.InputSystem;
using InputSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem.Interactions;

public class CharacterInputReader : CharacterInputSystem.IMovementActions
{
    public event UnityAction<bool> Sprint = delegate { };
    public event UnityAction<Vector2> SetMoveDirection = delegate { };

    private CharacterInputSystem inputActions;
    public CharacterInputReader()
    {
        if (inputActions == null)
        {
            inputActions = new CharacterInputSystem();
            inputActions.Movement.SetCallbacks(this);
            inputActions.Movement.Enable();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        SetMoveDirection?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
            Sprint?.Invoke(true);
        else if(context.phase == InputActionPhase.Canceled)
            Sprint?.Invoke(false);
    }
}
