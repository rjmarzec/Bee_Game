using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public int health = 50;
    public float attackTimer = 1.0f;
    public int direction = 1;

    Rigidbody2D rigidbody2d;
    float timer;
    Vector2 lookDirection;
    public GameObject redBulletPrefab;
    public GameObject blueBulletPrefab;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = attackTimer;
        lookDirection = new Vector2(direction, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Launch();
            timer = attackTimer;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int damageDealt)
    {
        health -= damageDealt;
    }

    void Launch()
    {
        if(direction == 1)
        {
            GameObject projectileObject = Instantiate(redBulletPrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            Projectile projectile = projectileObject.GetComponent<Projectile>();

            projectile.Launch(lookDirection, 300);
        }
        else
        {
            GameObject projectileObject = Instantiate(blueBulletPrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            Projectile projectile = projectileObject.GetComponent<Projectile>();

            projectile.Launch(lookDirection, 300);
        }
    }
}
