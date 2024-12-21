using UnityEngine;
using UnityEngine.InputSystem;
using InputSystems;
using UnityEngine.Events;

public class CharacterInputReader : CharacterInputSystem.IMovementActions
{
    public event UnityAction<Vector2> Move = delegate { };

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
        Move?.Invoke(context.ReadValue<Vector2>());
    }
}
