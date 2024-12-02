using UnityEngine;

public class StrafingEnemy : Enemy
{
    public float strafeSpeed = 3f;
    public float strafeCooldown = 5f;
    public float chaseSpeed = 8f;
    private Rigidbody rb;
    private float strafeDirection = 1;

    void Start()
    {
        LockAllRotations();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        InvokeRepeating("ChangeDirection", strafeCooldown, strafeCooldown); 
    }

    void ChangeDirection() {
        strafeDirection *= -1;
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
            Vector3 strafe = (transform.right * strafeDirection).normalized * strafeSpeed;
            strafe.y = 0;
            //transform.position += strafe;
            // apart from strafe, move towards the player
            Vector3 chase = (player.position - transform.position).normalized * chaseSpeed;
            chase.y = 0;
            
            Vector3 newvel = rb.velocity;
            newvel.x = strafe.x + chase.x;
            newvel.z = strafe.z + chase.z;
            rb.velocity = newvel;
        }
    }
}
