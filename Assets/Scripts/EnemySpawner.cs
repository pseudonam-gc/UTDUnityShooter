using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform FlyingEnemy;
    public Transform JumpingEnemy;
    public Transform StrafingEnemy;
    public Transform player;   // Reference to the player
    public float timer = 0;
    public float flyingCooldown = 40;
    public float jumpingCooldown = 30;
    public float strafingCooldown = 25;
    private float flyingTimer; 
    private float jumpingTimer;
    private float strafingtimer;
    // Start is called before the first frame update
    void Start()
    {
        flyingTimer = flyingCooldown;
        jumpingTimer = jumpingCooldown;
        strafingtimer = strafingCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        flyingTimer -= Time.deltaTime;
        jumpingTimer -= Time.deltaTime;
        strafingtimer -= Time.deltaTime;
        if (flyingTimer <= 0)
        {
            SpawnEnemyType(FlyingEnemy);
            flyingCooldown *= 0.93f;
            flyingTimer = flyingCooldown;
        }
        if (jumpingTimer <= 0)
        {
            SpawnEnemyType(JumpingEnemy);
            flyingCooldown *= 0.95f;
            jumpingTimer = jumpingCooldown;
        }
        if (strafingtimer <= 0)
        {
            SpawnEnemyType(StrafingEnemy);
            strafingtimer = strafingCooldown;
            flyingCooldown *= 0.97f;
        }
    }
    void SpawnEnemyType(Transform enemyType)
    {
        float x = Random.Range(-150, 150);
        float z = Random.Range(-150, 150);

        while (Vector3.Distance(new Vector3(x, 20, z), player.position) < 70)
        {
            x = Random.Range(-150, 150);
            z = Random.Range(-150, 150);
        }

        Instantiate(enemyType, new Vector3(x, 20, z), Quaternion.identity);
        
    }
    

}