using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    public Transform firePoint;
    public GameObject currentProjectilePrefab;
    public float bulletForce = 20f;
    public PlayerController player;

    public float bulletSpeed;

    public float fireRate = 2f;
    private float timeTillNextShot;


    void Start()
    {
        Debug.Log(player.currentForm);
        timeTillNextShot = .01f;
    }

    // Update is called once per frame
    void Update()
    {
        timeTillNextShot -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timeTillNextShot <= 0)
        {
            Shoot();
            timeTillNextShot = player.currentForm.fireRate;
            Debug.Log(player.currentForm);
        }          
    }

    void Shoot()
    {
        player.currentForm.shootingStyle.GetComponent<ShootingStyle>().Shoot(firePoint, player.currentForm.fireRate, player.currentForm.formProjectile, player.currentForm.projectileForce);
    }
}
