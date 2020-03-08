using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;

    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Launch the projectile with the given parameters
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        // Destory the projectile if it is far off the screen
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // On collision with a unit, deal damage and destroy the projectile
        Unit unit = other.collider.GetComponent<Unit>();
        if(unit != null)
        {
            unit.Damage(damage);
            Destroy(gameObject);
        }
    }
}
