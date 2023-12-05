using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] public float maxHealth = 500;
    [SerializeField] public float attackDamage = 20;
    [SerializeField] public float attackSpeed = 1.2f;
    [SerializeField] public float speedRun = 2;
    [SerializeField] public float jumpForce = 4;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Death();
        }
    }
    private void Death()
    {
        Debug.Log("Iam Dead");
    }
}
