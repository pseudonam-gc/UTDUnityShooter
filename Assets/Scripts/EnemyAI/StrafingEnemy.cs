using UnityEngine;

public class StrafingEnemy : Enemy
{
    public float strafeSpeed = 8f;
    public float strafeCooldown = 2.5f;
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
            Vector3 strafe = transform.right * strafeDirection * strafeSpeed * Time.deltaTime;
            strafe.y = 0;
            transform.position += strafe;
        }
    }
}
