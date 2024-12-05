using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damage = 10;
    public Camera fpsCam;
    public int maxAmmo = 300;
    public float range = 100f;
    public float fireRate = 500f;
    public int currentAmmo;
    private float reloadTime = 1.5f;
    private float nextTimeToFire = 0f;
    private bool isReloading = false;
   
    public TextMeshProUGUI ammoDisplay;

    void Start()
    {
        if(currentAmmo == -1)
            currentAmmo = maxAmmo;
    }

    void Update()
    {
        if(isReloading)
            return;
        if(Input.GetKeyDown(KeyCode.Mouse1) && currentAmmo < maxAmmo && isReloading == false)
            StartCoroutine(Reload());
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (AmmoManager.Instance.ammoDisplay != null)
            ammoDisplay.text = $"{currentAmmo}/{maxAmmo}";
    }
    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    private void Shoot()
    {
        currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

   
}