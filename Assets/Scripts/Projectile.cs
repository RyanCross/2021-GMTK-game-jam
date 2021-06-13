using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hitEffect; //put some explosion or some shit here.
    public float timeToLive = 2.0f;

    private void Start()
    {
        Destroy(gameObject, timeToLive);
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
       IKillable target = hitInfo.GetComponent<IKillable>();
        if (target != null && hitInfo.tag != "Player") // target is something that can take dmg, but is not the player
        {
            target.TakeDamage(1);
            Debug.Log("damage taken");
        }
        
        if(hitInfo.tag != "Projectile" && hitInfo.tag != "Player") 
        {
                Destroy(gameObject);   
        }
        
    }
}
