using UnityEngine;

public class ChargingEnemy : Enemy
{
    public float speed = 10f;

    void Start()
    {
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
