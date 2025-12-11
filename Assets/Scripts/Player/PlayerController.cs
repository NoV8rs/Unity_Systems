using UnityEngine;
using UnityEngine.InputSystem;

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
    [SerializeField] private InputActionReference playerInputAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<CircleCollider2D>();
    }
    
    void OnEnable()
    {
        playerInputAction.action.Enable();
    }
    
    void OnDisable()
    {
        playerInputAction.action.Disable();
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
        _movementInput = playerInputAction.action.ReadValue<Vector2>().normalized;
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
