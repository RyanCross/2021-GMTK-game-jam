using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IKillable 
{
    [SerializeField] float MaxHealth = 10;
    private float health = 0;

    public void Start()
    {
        health = MaxHealth;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Max(health - damage, 0);
        if (health <= 0) Die();
    }

    public float GetFractionHP()
    {
        return (health / MaxHealth);
    }

}
