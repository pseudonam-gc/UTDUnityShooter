using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform FlyingEnemy;
    public Transform JumpingEnemy;
    public Transform StrafingEnemy;
    public Transform player;   // Reference to the player
    public LayerMask groundLayer;
    public float timer = 0;
    public float flyingCooldown = 40f/1.5f;
    public float jumpingCooldown = 30f/1.5f;
    public float strafingCooldown = 25f/1.5f;
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
            flyingCooldown = Mathf.Max(3f, flyingCooldown*0.97f);
            flyingTimer = flyingCooldown;
        }
        if (jumpingTimer <= 0)
        {
            SpawnEnemyType(JumpingEnemy);
            jumpingCooldown = Mathf.Max(3f, jumpingCooldown*0.97f);
            jumpingTimer = jumpingCooldown;
        }
        if (strafingtimer <= 0)
        {
            SpawnEnemyType(StrafingEnemy);
            strafingtimer = strafingCooldown;
            strafingCooldown = Mathf.Max(3f, strafingCooldown*0.97f);
        }
    }
    void SpawnEnemyType(Transform enemyType)
    {
        float x = Random.Range(-150, 150);
        float z = Random.Range(-150, 150);
        while (Vector3.Distance(new Vector3(x, player.position.y, z), player.position) < 70)
        {
            x = Random.Range(-150, 150);
            z = Random.Range(-150, 150);
        }

        Vector3 spawnloc = new Vector3(x, 50, z);
        RaycastHit hit;
        if (Physics.Raycast(spawnloc, Vector3.down, out hit, 100f, groundLayer)) {
            spawnloc.y = hit.point.y + 2;
        } 
        Instantiate(enemyType, spawnloc, Quaternion.identity);
        
    }
    

}
