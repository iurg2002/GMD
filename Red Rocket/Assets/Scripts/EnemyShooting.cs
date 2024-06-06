using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float bulletSpeed = 6f;  // Public variable to set bullet speed from inspector
    public float spawnInterval = 2f;  // Public variable to set spawn interval from inspector

    private float timer;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            timer = 0;
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        EnemyBulletScript bulletScript = bullet.GetComponent<EnemyBulletScript>();
        if (bulletScript != null)
        {
            bulletScript.speed = bulletSpeed;  // Set the bullet speed
        }

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 direction = (bullet.transform.position - bulletSpawn.position).normalized * bulletSpeed;
            rb.velocity = new Vector2(direction.x, direction.y);
        }
    }
}
