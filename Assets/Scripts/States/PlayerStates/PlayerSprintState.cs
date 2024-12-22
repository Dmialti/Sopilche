using UnityEngine;

public class PlayerSprintState : PlayerBaseState
{
    public PlayerSprintState(PlayerLocomotionManager playerLocomotionManager) : base(playerLocomotionManager) { }
    public override void OnEnter()
    {
        base.OnEnter();
        CurrentSpeed = 6;
    }

    public override void OnExit()
    {
        base.OnExit();
    }
    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        playerLocomotionManager.Move(CurrentSpeed);
    }
}
