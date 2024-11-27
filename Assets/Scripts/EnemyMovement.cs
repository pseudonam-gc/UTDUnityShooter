using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    private NavMeshAgent agent; // Reference to the NavMeshAgent

    // Range within which the enemy starts moving toward the player
    public float detectionRange = 20f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Move toward the player only if within detection range
            if (distanceToPlayer <= detectionRange)
            {
                if (agent.isOnNavMesh)
                { 
                    agent.SetDestination(player.position);
                }
            }
            else
            {
                // Stop moving when player is out of range
                if (agent.isOnNavMesh)
                {
                    agent.SetDestination(player.position);
                }
            }
        }
    }
}
