using UnityEngine;

public class MovementManager : MonoBehaviour
{
    #region Variables
    private Rigidbody2D rigidbody;

    private CharacterInputReader inputReader;

    private float currentSpeed;

    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 3;   
    [SerializeField] private float runSpeed = 6;

    #endregion

    #region Methods
    void Move()
    {
        rigidbody.linearVelocity = inputReader.MoveDirection * currentSpeed;
    }
    void Sprint(bool isSprinting)
    {
        currentSpeed = isSprinting ? runSpeed : walkSpeed;
    }
    #endregion

    #region MonoBehaviour Callbacks
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        inputReader = new CharacterInputReader();

        currentSpeed = walkSpeed;
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Move();
    }

    void OnEnable()
    {
        inputReader.Sprint += Sprint;
    }

    void OnDisable()
    {
        inputReader.Sprint -= Sprint;
    }
    #endregion
}
