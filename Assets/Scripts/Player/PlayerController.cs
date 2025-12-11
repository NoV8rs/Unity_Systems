using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private CircleCollider2D _collider2D;
    
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
        PlayerMovement();
    }

    /// <summary>
    /// Handles player movement logic based on keyboard input.
    /// This method reads input from predefined keys and calculates the movement vector.
    /// It then moves the GameObject's Rigidbody2D component accordingly to implement player-controlled movement.
    /// </summary>
    private void PlayerMovement()
    {
        Vector2 movement = Vector2.zero;
        if (Input.GetKey(moveUpKey))
        {
            movement.y += 1;
        }

        if (Input.GetKey(moveDownKey))
        {
            movement.y -= 1;
        }
        
        if (Input.GetKey(moveLeftKey))
        {
            movement.x -= 1;
        }
        
        if (Input.GetKey(moveRightKey))
        {
            movement.x += 1;
        }
        
        movement = movement.normalized * (moveSpeed * Time.deltaTime);
        _rigidbody2D.MovePosition(_rigidbody2D.position + movement);
    }
}
