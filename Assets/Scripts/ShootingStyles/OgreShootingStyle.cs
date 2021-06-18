using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreShootingStyle : ShootingStyle
{

    override public void Shoot(Transform firePoint, float fireRate, GameObject projectileToFire, float projectileForce)
    {
        GameObject bullet = Instantiate(projectileToFire, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(projectileToFire, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce((-firePoint.up * projectileForce), ForceMode2D.Impulse);
    }
}
