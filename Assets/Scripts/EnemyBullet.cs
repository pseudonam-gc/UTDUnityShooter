using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject player;
    public float speed = 10f; // Speed of the bullet

    private void Start()
    {
        // Find the player by tag (ensure your player object has the "Player" tag)
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            // Calculate direction to the player
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Assign velocity to the bullet's Rigidbody
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * speed;
            }
        }

        // Destroy the bullet after 5 seconds to clean up
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Adjust damage as needed
            }
            Destroy(gameObject); // Destroy the bullet
        }
        else if (collision.gameObject.CompareTag("wall") || collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject); // Destroy on hitting walls or ground
        }
    }
}
