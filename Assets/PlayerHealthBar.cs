using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthBar : MonoBehaviour
{
    public int Health { get; set; }
    public int maxHealth { get; set; }
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetMaxHealth(int newMax)
    {
        this.maxHealth = newMax;
        slider.maxValue = newMax;
    }

    public void SetHealth(int currentHealth)
    {
        this.Health = currentHealth;
        slider.value = currentHealth;
    }

}
