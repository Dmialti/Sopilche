using UnityEngine;

public class CharacterLocomotionManager : MonoBehaviour
{
    #region Variables
    private Rigidbody2D rigidbody;

    protected Vector2 MoveDirection;

    protected StateMachine stateMachine;

    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 3;   
    [SerializeField] private float runSpeed = 6;

    protected bool isSprinting;

    #endregion

    #region Methods
    public void Move(float speed)
    {
        rigidbody.linearVelocity = MoveDirection * speed;
    }
    
    protected void SetMoveDirection(Vector2 value) => MoveDirection = value;

    protected void SetSprinting(bool value) => isSprinting = value;
    #endregion

    #region MonoBehaviour Callbacks
    protected void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        stateMachine = new StateMachine();
    }

    protected void Update()
    {
        stateMachine.Update();
    }

    protected void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    protected void OnEnable()
    {
    }

    protected void OnDisable()
    {
    }
    #endregion
}
