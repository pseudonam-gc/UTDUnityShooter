using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject player;
    public float speed = 10f;
    public int damage = 10;
    private Rigidbody rb; 

    private void Start()
    {
    }

    public void InitializeVel(Vector3 direction) {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player playerComp = collision.gameObject.GetComponent<Player>();
            playerComp.TakeDamage(damage);
        } 
        Destroy(gameObject);
    }
}
