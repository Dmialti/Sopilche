using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected PlayerLocomotionManager playerLocomotionManager;

    protected float CurrentSpeed;

    public PlayerBaseState(PlayerLocomotionManager playerLocomotionManager)
    {
        this.playerLocomotionManager = playerLocomotionManager;
    }
    public virtual void OnEnter()
    {
    }

    public virtual void OnExit()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual void Update()
    {
    }
}
