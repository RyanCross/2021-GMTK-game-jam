using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D myBody;
    Vector2 movement;

    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float attackDistance = 2.0f; //should be 0 or very small for melee enemies
    public float aggroRange;
    bool isAggro;

    // Start is called before the first frame update
    void Start()
    {
        isAggro = false;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (myBody == null)
        {
            myBody = GetComponent<Rigidbody2D>();
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("currentRange");
        Debug.Log(Vector2.Distance(player.transform.position, gameObject.transform.position));
        if (Vector2.Distance(player.transform.position, gameObject.transform.position) <= aggroRange)
            isAggro = true;

        if (isAggro == true)
        {
            //Player to the left
            if (player.transform.position.x < gameObject.transform.position.x)
            {
                //Look left
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                //Move left if moving
                movement.x = -1;
            }
            //Player to the right
            else if (player.transform.position.x > gameObject.transform.position.x)
            {
                //look right
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                //Move right if moving
                movement.x = 1;
            }

            //Player above
            if (player.transform.position.y > gameObject.transform.position.y)
            {
                //Move up if moving
                movement.y = 1;
                //Move if not within attack range
                if (Vector3.Distance(myBody.position, player.transform.position) > attackDistance)
                {
                    myBody.MovePosition(myBody.position + movement * moveSpeed * Time.fixedDeltaTime);
                }
            }
            //Player below
            else if (player.transform.position.y < gameObject.transform.position.y)
            {
                //Move down if moving
                movement.y = -1;
                //Move if not within attack range
                if (Vector3.Distance(myBody.position, player.transform.position) > attackDistance)
                {
                    myBody.MovePosition(myBody.position + movement * moveSpeed * Time.fixedDeltaTime);
                }
            }
        }
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            IKillable target = collision.collider.GetComponent<IKillable>();
            if (target != null)
            {
                target.TakeDamage(1);
                Debug.Log("damage taken");
            }
            Destroy(gameObject);
        }

    }
}
