using UnityEngine;

public class StrafingEnemy : Enemy
{
    public float strafeSpeed = 3f;
    public float strafeDistance = 5f;
    private Transform player;
    private float strafeDirection = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
            Vector3 strafe = transform.right * strafeDirection * strafeSpeed * Time.deltaTime;
            transform.position += strafe;

            // Change direction at strafeDistance
            if (Vector3.Distance(transform.position, player.position) > strafeDistance)
            {
                strafeDirection *= -1;
            }
        }
    }
}
