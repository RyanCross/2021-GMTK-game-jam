using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ShootingStyle : MonoBehaviour
{
    public abstract void Shoot(Transform firePoint, float fireRate, GameObject projectileToFire, float projectileForce);
}
