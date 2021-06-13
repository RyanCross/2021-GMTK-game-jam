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
    public PlayerHealthBar healthBar;
    public SpriteRenderer renderer;
    
    Vector2 movement;
    Vector2 mousePos;
    [SerializeField] int curHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentForm = allForms[0]; // 0 = default form, in this case, our humanoid elf
        curHealth = currentForm.maxHealth;
        healthBar.SetMaxHealth(currentForm.maxHealth);
        healthBar.SetHealth(currentForm.maxHealth);

        Debug.Log("Current Health is:" + curHealth);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (movement.x != 0f || movement.y != 0f)
            animator.SetBool("isMoving", true);
        else
            animator.SetBool("isMoving", false);

        if (movement.x < 0)
        {
            renderer.flipX = true;
        }
        if (movement.x > 0)
        {
            renderer.flipX = false;
        }


        if (Input.GetKeyDown(KeyCode.Space))
            TakeDamage(1);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentForm.moveSpeed * Time.fixedDeltaTime);
    }

    private void changeForm()
    {
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
        healthBar.SetHealth(curHealth);
        
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
