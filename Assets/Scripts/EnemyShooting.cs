using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private GameObject player;
    private Camera playerCamera;
    public GameObject projectilePrefab;
    private Transform firePoint;
    public float fireRate = 2f;
    public float shotQuantity = 1f;
    public float spread = 0f;
    public int bulletDamage = 10;
    public float shootingRange = 30f;
    private float nextFireTime = 0f;

    void Start() {
        if (firePoint == null) {
            firePoint = transform;
        }
        player = GameObject.FindWithTag("Player");
        if (player != null) {
            playerCamera = player.GetComponentInChildren<Camera>();
        }
    }

    void Update()
    {
        if (player != null && Time.time >= nextFireTime)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= shootingRange)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void Shoot()
    {
        if (player != null && playerCamera != null) {
            for (int i = 0; i < shotQuantity; i++) {
                GameObject projectileObject = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                EnemyBullet projectile = projectileObject.GetComponent<EnemyBullet>();
                Vector3 direction = (player.transform.position - transform.position).normalized;

                float spreadR = Random.Range(0, spread);
                float spreadTheta = Random.Range(0, 360);
                Quaternion spreadRotation = Quaternion.Euler(spreadR * Mathf.Cos(spreadTheta), spreadR * Mathf.Sin(spreadTheta), 0);
                direction = spreadRotation * direction;
                projectile.InitializeVel(direction);
                projectile.damage = bulletDamage;
            }
        }
    }
}