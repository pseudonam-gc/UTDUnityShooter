using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player"); // Assuming your player has the "Player" tag
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
