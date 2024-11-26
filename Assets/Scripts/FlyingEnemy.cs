using UnityEngine;

public class FlyingEnemy : Enemy
{
    public float speed = 5f;
    public float hoverHeight = 3f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + Vector3.up * hoverHeight;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
