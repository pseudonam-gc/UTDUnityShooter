using UnityEngine;

public class FlyingEnemy : Enemy
{
    public float speed = 5f;
    public float hoverHeight = 3f;
    public float stopDistance = 3f;

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
            if (Vector3.Distance(transform.position, targetPosition) > stopDistance) {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        } else {
            Debug.LogWarning("Player not found!");
        }
    }
}
