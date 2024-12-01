using UnityEngine;

public class StrafingEnemy : Enemy
{
    public float strafeSpeed = 3f;
    public float strafeDistance = 5f;
    private Rigidbody rb;
    private Transform player;
    private float strafeDirection = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("ChangeDirection", 1.5f, 1.5f); // Changes direction every 2 seconds
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
            transform.position += strafe;
        }
    }
}
