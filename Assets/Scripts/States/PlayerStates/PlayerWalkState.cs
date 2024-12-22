using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerLocomotionManager playerLocomotionManager) : base(playerLocomotionManager) { }
    public override void OnEnter()
    {
        base.OnEnter();
        CurrentSpeed = 3;
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
