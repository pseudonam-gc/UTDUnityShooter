using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damage = 10;
    public Camera fpsCam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire button is clicked
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}