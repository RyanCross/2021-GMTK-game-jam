using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject hitEffect; //put some explosion or some shit here.
    public float timeToLive = 2.0f;
    private GameObject player;
    public float speed = 5.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, timeToLive);
        
        gameObject.transform.LookAt(player.transform);
        
        Vector2 direction = player.transform.position - gameObject.transform.position;
        Vector2 newvector = direction.normalized * speed;
        gameObject.GetComponent<Rigidbody2D>().velocity = newvector;
    }

    private void Update()
    {
        Vector3 rotation = Quaternion.LookRotation(gameObject.transform.position).eulerAngles;
        rotation.x = 0f;
        rotation.z = 0f;

        transform.rotation = Quaternion.Euler(rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IKillable target = other.GetComponent<IKillable>();
            if (target != null)
            {
                target.TakeDamage(1);
                Debug.Log("damage taken");
            }
            Destroy(gameObject);
        }
    }
}