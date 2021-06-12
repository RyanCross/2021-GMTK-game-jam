using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IKillable
{
    public List<ShapeshiftForms> allForms;
    public ShapeshiftForms currentForm { get; set; }

    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;
    
    Vector2 movement;
    Vector2 mousePos;
    [SerializeField] int curHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentForm = allForms[0]; // 0 = default form, in this case, our humanoid elf
        curHealth = currentForm.maxHealth;
        Debug.Log("Current Health is:" + curHealth);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentForm.moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position; // This vector math gets us a vector that points from our player to our mouse position
        // set the rotation of the player using the look direction
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void changeForm()
    {
        Debug.Log(allForms.FindIndex(form => form.formName == currentForm.formName) + 1);
        Debug.Log(allForms.Count);
        if (allForms.FindIndex(form => form.formName == currentForm.formName) + 1 < allForms.Count)
            currentForm = allForms[allForms.FindIndex(form => form.formName == currentForm.formName) + 1];
        else
            currentForm = allForms[0];
        animator.runtimeAnimatorController = currentForm.animatorController;
    }

    private void OnEnable()
    {
        GameEvents.shapeshiftTimerElapsed += changeForm;
    }

    private void OnDisable()
    {
        GameEvents.shapeshiftTimerElapsed -= changeForm;
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        
        if(curHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //death effects, game over event trigger, etc
        Destroy(gameObject);
    }


}
