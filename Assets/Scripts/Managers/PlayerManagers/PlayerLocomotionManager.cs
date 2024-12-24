using UnityEngine;

public class PlayerLocomotionManager : CharacterLocomotionManager
{
    private CharacterInputReader inputReader;

    //States
    private PlayerIdleState idleState;
    private PlayerWalkState walkState;
    private PlayerSprintState sprintState;

    void Awake()
    {
        base.Awake();
        inputReader = new CharacterInputReader();

        idleState = new PlayerIdleState(this);
        walkState = new PlayerWalkState(this);
        sprintState = new PlayerSprintState(this);

        stateMachine.AddTransition(idleState, walkState, new Predicate(() => MoveDirection != Vector2.zero && isSprinting));
        stateMachine.AddTransition(idleState, walkState, new Predicate(() => MoveDirection != Vector2.zero));
        stateMachine.AddTransition(walkState, idleState, new Predicate(() => MoveDirection == Vector2.zero));
        stateMachine.AddTransition(walkState, sprintState, new Predicate(() => isSprinting));
        stateMachine.AddTransition(sprintState, walkState, new Predicate(() => MoveDirection != Vector2.zero && !isSprinting));
        stateMachine.AddTransition(sprintState, walkState, new Predicate(() => MoveDirection == Vector2.zero));

        stateMachine.SetState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void OnEnable()
    {
        inputReader.Sprint += SetSprinting;
        inputReader.SetMoveDirection += SetMoveDirection;
    }

    private void OnDisable()
    {
        inputReader.Sprint -= SetSprinting;
        inputReader.SetMoveDirection -= SetMoveDirection;
    }
}
