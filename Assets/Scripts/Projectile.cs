using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hitEffect; //put some explosion or some shit here.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");
        //Instantiate hitEffect GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity)
        // Deal Damage Event
        Destroy(gameObject);

    }
}