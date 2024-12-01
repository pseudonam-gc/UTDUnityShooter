using UnityEngine;

public class FlyingEnemy : Enemy
{
    public float speed = 5f;
    public float hoverHeight = 3f;
    private Transform player;
    private Transform capsule;

    void Start()
    {
        LockAllRotations();
        DisableGravity();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = new Vector3(player.position.x, hoverHeight, player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
