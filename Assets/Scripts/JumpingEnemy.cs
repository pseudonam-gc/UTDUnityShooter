using UnityEngine;

public class JumpingEnemy : Enemy
{
    public float jumpForce = 5f;
    private Rigidbody rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("JumpTowardsPlayer", 2f, 3f); // Jumps every 3 seconds
    }


    void JumpTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 jumpDirection = (player.position - transform.position).normalized;
            jumpDirection.y = 0;
            rb.AddForce(jumpDirection * jumpForce + Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}