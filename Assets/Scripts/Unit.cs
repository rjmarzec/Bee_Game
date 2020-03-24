using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int direction = 1;
    public int health = 50;
    public float attackCooldown = 1.0f;

    public GameObject projectilePrefabLeft;
    public GameObject projectilePrefabRight;
    GameObject projectilePrefab;
    public int projectileForce = 300;

    Rigidbody2D rigidbody2d;
    Vector2 lookDirection;
    float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        lookDirection = new Vector2(direction, 0);
        attackTimer = attackCooldown;
        projectilePrefab = projectilePrefabLeft;

        // Flip the direction the unit is facing if they are on the right side
        if (direction == -1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            projectilePrefab = projectilePrefabRight;

            // Change the layer of the unit so it doesn't hit itself
            gameObject.layer = LayerMask.NameToLayer("UnitRight");
        }
    }

    // Update is called once per frame
    virtual public void Update()
    {
        // Check if the unit should attack
        if (attackCooldown != -1.0f)
        {
            attackTimer -= Time.deltaTime;

            // If the unit is ready to attack, do so
            if (attackTimer < 0)
            {
                Attack();
                // Reset the attack timer
                attackTimer = attackCooldown;
            }
        }

        // Destroy the unit if they have no more health
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // When called, launch a projectile from the unit, as specified by
    // the public variables of unit.
    public void Attack()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();

        projectile.Launch(lookDirection, projectileForce);
    }

    // Take damage. It's as simple as that.
    public void Damage(int damageTaken)
    {
        health -= damageTaken;
    }
}