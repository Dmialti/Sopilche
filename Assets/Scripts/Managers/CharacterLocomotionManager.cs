using UnityEngine;

public class MovementManager : MonoBehaviour
{
    #region Variables
    private CharacterInputReader inputReader;

    [SerializeField]
    private float speed;

    private Rigidbody2D rigidbody;
    #endregion

    #region Methods
    void Move(Vector2 movement)
    {
        rigidbody.linearVelocity = movement * speed;
    }
    #endregion

    #region MonoBehaviour Callbacks
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        inputReader = new CharacterInputReader();
    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        inputReader.Move += Move;
    }

    void OnDisable()
    {
        inputReader.Move -= Move;
    }
    #endregion
}
