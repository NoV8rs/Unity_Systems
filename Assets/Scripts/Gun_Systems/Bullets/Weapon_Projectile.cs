using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[DisallowMultipleComponent]
public class Weapon_Projectile : MonoBehaviour
{
    public float projectileSpeed = 10f;
    public float lifeTime = 5f;
    private Rigidbody2D _rigidbody2D;
    private float _lifeTimer;
    
    // Could add particles or sound effects on impact later
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _lifeTimer = lifeTime;
        _rigidbody2D.linearVelocity = transform.right * projectileSpeed;
    }
    
    void Update()
    {
        _lifeTimer -= Time.deltaTime;
        if (_lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
