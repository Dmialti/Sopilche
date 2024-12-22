using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerLocomotionManager playerLocomotionManager) : base(playerLocomotionManager) { }
    public override void OnEnter()
    {
        base.OnEnter();
        CurrentSpeed = 0;
        playerLocomotionManager.Move(CurrentSpeed);
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
    }
}
