using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private CircleCollider2D _collider2D;
    private Vector2 _movementInput;
    
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    
    [Header("Keyboard Bindings")]
    [SerializeField] private KeyCode moveUpKey = KeyCode.W;
    [SerializeField] private KeyCode moveDownKey = KeyCode.S;
    [SerializeField] private KeyCode moveLeftKey = KeyCode.A;
    [SerializeField] private KeyCode moveRightKey = KeyCode.D;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadMovementInput();
    }

    // FixedUpdate is called at fixed time intervals for physics
    void FixedUpdate()
    {
        ApplyMovement();
    }

    /// <summary>
    /// Reads player movement input from keyboard.
    /// Called in Update() to ensure no input is missed.
    /// </summary>
    private void ReadMovementInput()
    {
        _movementInput = Vector2.zero;
        
        if (Input.GetKey(moveUpKey))
        {
            _movementInput.y += 1;
        }

        if (Input.GetKey(moveDownKey))
        {
            _movementInput.y -= 1;
        }
        
        if (Input.GetKey(moveLeftKey))
        {
            _movementInput.x -= 1;
        }
        
        if (Input.GetKey(moveRightKey))
        {
            _movementInput.x += 1;
        }
        
        _movementInput.Normalize();
    }

    /// <summary>
    /// Applies movement to the Rigidbody2D.
    /// Called in FixedUpdate() for consistent physics behavior.
    /// </summary>
    private void ApplyMovement()
    {
        Vector2 movement = _movementInput * (moveSpeed * Time.fixedDeltaTime);
        _rigidbody2D.MovePosition(_rigidbody2D.position + movement);
    }
}
