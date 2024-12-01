using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform firePoint; // Where the projectile spawns
    public float shootInterval = 2f; // Time between shots
    public float projectileSpeed = 10f; // Speed of the projectile
    public bool aimAtPlayer = true; // Whether the enemy should aim at the player

    private float shootTimer;
    private Transform player;

    void Start()
    {
        // Find the player in the scene
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        if (firePoint == null || projectilePrefab == null)
        {
            Debug.LogWarning("FirePoint or ProjectilePrefab is not set on " + gameObject.name);
            return;
        }

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Optionally aim at the player
        if (aimAtPlayer && player != null)
        {
            Vector3 directionToPlayer = (player.position - firePoint.position).normalized;
            projectile.transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
        //Add a check for whether the player is within range before shooting
        if (Vector3.Distance(player.position, transform.position) <= 15f) 
        {
            Shoot();
        }
        // Apply velocity to the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = projectile.transform.forward * projectileSpeed;
        }
    }
}
