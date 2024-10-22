using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    private float nextFireTime = 0f;

    public float bulletVelocity = 30;
    public float bulletLifespan = 3f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
{
    GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    
    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    rb.velocity = firePoint.forward * bulletVelocity;

    Collider bulletCollider = bullet.GetComponent<Collider>();
    Collider[] enemyColliders = GetComponentsInChildren<Collider>();

    foreach (Collider enemyCollider in enemyColliders)
    {
        if (enemyCollider != bulletCollider)
        {
            Physics.IgnoreCollision(bulletCollider, enemyCollider);
        }
    }

    Destroy(bullet, bulletLifespan);
	}	
}
