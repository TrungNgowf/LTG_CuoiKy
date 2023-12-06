using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public float maxHealth = 300;
    [SerializeField] public float attackDamage = 20;
    [SerializeField] public float attackSpeed = 1.2f;
    [SerializeField] public float speedRun = 1.5f;
    [SerializeField] public float jumpForce = 3.4f;
    [SerializeField] public float armor = 10f;
    [SerializeField] public float maxVirtualHealth = 50f;
    [SerializeField] public float maxMana = 100f;
    float currentMana = 0f;
    float currentVirtualHealth = 0;
    float currentHealth;
    public Slider healthBar;
    public Slider virtualHealthBar;
    public Slider manaBar;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        virtualHealthBar.maxValue = maxVirtualHealth;
        virtualHealthBar.value = currentVirtualHealth;
        manaBar.maxValue = maxMana;
        manaBar.value = currentMana;
    }

    void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        animator.SetTrigger("Hitted");
        float finalDamage = damage - armor;
        if (currentVirtualHealth > 0) {
            currentVirtualHealth -= finalDamage;
            currentVirtualHealth = Math.Clamp(currentVirtualHealth, 0, maxVirtualHealth);
            virtualHealthBar.value = currentVirtualHealth;
        }
        else
        {
            currentHealth -= finalDamage;
            currentHealth = Math.Clamp(currentHealth, 0, maxHealth);
            healthBar.value = currentHealth;
            if (currentHealth <= 0)
            {
                animator.SetBool("IsDead", true);
                Dead();
            }
        }
        
    }
    private void Dead()
    {
        Debug.Log("Iam Dead");
    }
}