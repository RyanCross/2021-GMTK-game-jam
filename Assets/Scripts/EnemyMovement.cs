using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D myBody;
    Vector2 movement;

    private float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(myBody == null)
        {
            myBody = GetComponent<Rigidbody2D>();
        }
    }

    private void FixedUpdate()
    {
        //Player to the left
        if(player.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1); //look left
            movement.x = -1;
        }
        //Player to the right
        else if(player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1); //look right
            movement.x = 1;
        }
             
        //Player above
        if(player.transform.position.y > gameObject.transform.position.y)
        {
            movement.y = 1;
            myBody.MovePosition(myBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        //Player below
        if (player.transform.position.y < gameObject.transform.position.y)
        {
            movement.y = -1;
            myBody.MovePosition(myBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
