using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damage = 10;
    public Camera fpsCam;
    public bool isShooting, readyToShoot;
    bool allowReset = true;
    public float shootingDelay = 2f;
    public float spreadIntensity;
    public int bulletsPerBurst = 3;
    public int burstBulletsLeft;
    public float reloadTime;
    public int magazineSize, bulletsLeft;
    public bool isReloading;
    public TextMeshProUGUI ammoDisplay;
    public enum shootingMode
    {
        Single,Burst,Auto
    }

    public shootingMode currentShootingMode;

    private void Awake()
    {
        readyToShoot = true;
        burstBulletsLeft = bulletsPerBurst;
        bulletsLeft = magazineSize;
    }

    void Update()
    {
        if (currentShootingMode == shootingMode.Auto)
            isShooting = Input.GetKey(KeyCode.Mouse0);
        else if (currentShootingMode == shootingMode.Burst || currentShootingMode == shootingMode.Single)
            isShooting = Input.GetKeyDown(KeyCode.Mouse0);
        if(readyToShoot && isShooting && bulletsLeft > 0)
        {
            burstBulletsLeft = bulletsPerBurst;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && bulletsLeft < magazineSize && isReloading == false)
            Reload();
        if (readyToShoot && !isShooting && isReloading == false && bulletsLeft <= 0)
            Reload();

        if (AmmoManager.Instance.ammoDisplay != null)
            ammoDisplay.text = $"{bulletsLeft / bulletsPerBurst}/{magazineSize / bulletsPerBurst}";
    }

    private void Shoot()
    {
        bulletsLeft--;
        readyToShoot=false;
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

    private void Reload()
    {
        isReloading = true;
        Invoke("ReloadCompleted", reloadTime);
    }
    private void ReloadCompleted()
    {
        bulletsLeft = magazineSize;
        isReloading = false;
    }
}