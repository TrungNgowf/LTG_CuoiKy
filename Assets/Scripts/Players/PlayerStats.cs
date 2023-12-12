using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private float maxHealth = 300;
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
    AudioManager audioManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (gameObject.name == "Huntress")
        {
            currentHealth = maxHealth;
        }
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        virtualHealthBar.maxValue = maxVirtualHealth;
        virtualHealthBar.value = currentVirtualHealth;
        manaBar.maxValue = maxMana;
        manaBar.value = currentMana;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {

    }

    public void GainMana(float mana)
    {
        currentMana += mana;
        currentMana = Math.Clamp(currentMana, 0, maxMana);
        manaBar.value = currentMana;
    }
    public void GainHealth(float health)
    {
        currentHealth += health;
        currentHealth = Math.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = currentHealth;
    }
    public void TakeDamage(float damage)
    {
        animator.SetTrigger("Hitted");
        audioManager.PlaySFX(audioManager.player_takeHit);
        float finalDamage = damage - armor;
        if (currentVirtualHealth > 0)
        {
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
    public bool checkMaxMana()
    {
        return currentMana >= maxMana;
    }
    public float getCurrentHealth()
    {
        return currentHealth;
    }
    public void setCurrentHealth(float health)
    {
        healthBar.value = health;
        currentHealth = health;
    }
    public void setVirtualHealth()
    {
        virtualHealthBar.value = maxVirtualHealth;
        currentVirtualHealth = maxVirtualHealth;
    }
    public void setCurrentMana(float mana)
    {
        currentMana = mana;
        manaBar.value = mana;
    }
}
