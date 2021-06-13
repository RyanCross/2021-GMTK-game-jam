using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] float timeToFire = 2.0f;
    [SerializeField] float timeSinceFired = 0;
    [SerializeField] GameObject currentProjectilePrefab;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceFired += Time.deltaTime;
        Debug.Log("Time since fire: " + timeSinceFired);

        if(timeSinceFired >= timeToFire)
        {
            GameObject bullet = Instantiate(currentProjectilePrefab, gameObject.transform.position, gameObject.transform.rotation);
            timeSinceFired = 0f;
            Debug.Log("Firing");
        }
    }
}
