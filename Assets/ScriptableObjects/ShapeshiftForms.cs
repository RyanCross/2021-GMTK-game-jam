using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Form", menuName = "ScriptableObjects/ShapeshiftForms", order = 1)]
public class ShapeshiftForms : ScriptableObject
{
    public string formName;
    public float moveSpeed;
    public int maxHealth;
    public float fireRate;
    public float projectileForce;
    public RuntimeAnimatorController animatorController;
    public GameObject formProjectile;
    public GameObject shootingStyle;
}
