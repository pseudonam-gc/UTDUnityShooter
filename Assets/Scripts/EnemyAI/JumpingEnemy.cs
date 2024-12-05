using UnityEngine;

public class JumpingEnemy : Enemy
{
    public float upwardForce = 7f;
    public float horizontalForce = 10f;
    public float leapInterval = 2.5f;    // Time interval between leaps
    public LayerMask groundLayer;      // Layer used to check if on the ground
    private Rigidbody rb;
    private float leapTimer;

    void Start()
    {
        LockAllRotations();
        rb = GetComponent<Rigidbody>();

        leapTimer = leapInterval;
        groundLayer = LayerMask.GetMask("Ground");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        leapTimer -= Time.deltaTime;

        if (IsGrounded() && leapTimer <= 0f && player != null)
        {
            LookAtPlayer();
            LeapTowardsPlayer();
            leapTimer = leapInterval;
        }
    }

    private bool IsGrounded()
    {
        // Check if the enemy is on the ground
        return Physics.Raycast(transform.position, Vector3.down, 3f, groundLayer);
    }

    private void LeapTowardsPlayer()
    {
        // Reset vertical velocity before applying new forces
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        // Calculate direction to the player, ignoring vertical (Y-axis)
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Vector3 horizontalDirection = new Vector3(directionToPlayer.x, 0, directionToPlayer.z).normalized;

        // Apply forces: upward force and horizontal force
        Vector3 leapForce = Vector3.up * upwardForce + horizontalDirection * horizontalForce;
        rb.AddForce(leapForce, ForceMode.Impulse);
    }

    private void LookAtPlayer()
    {
        Vector3 lookAtTarget = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookAtTarget);
    }
}