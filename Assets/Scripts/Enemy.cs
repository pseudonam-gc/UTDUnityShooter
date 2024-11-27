using UnityEngine;
using UnityEngine.AI; // Required for NavMeshAgent

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;

    private NavMeshAgent agent; // Reference to the NavMeshAgent
    private Transform player;   // Reference to the player

    void Start()
    {
        // Initialize NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // Find the player in the scene using their tag
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        // Move toward the player if the player exists
        if (agent != null && agent.isOnNavMesh && player != null)
        {
            agent.SetDestination(player.position);
        }
    }

    public virtual void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void AttackPlayer(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    protected virtual void Die()
    {
        // Play death animation or effects here.
        Destroy(gameObject);
    }
}
