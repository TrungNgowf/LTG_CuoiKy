using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntressStats : MonoBehaviour
{
    [SerializeField] public int maxHealth = 500;
    [SerializeField] public int attackDamage = 20;
    [SerializeField] public float attackSpeed = 1.2f;
    [SerializeField] public float speedRun = 2;
    [SerializeField] public float jumpForce = 4;
    [SerializeField] public float attackRange = 0.5f;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
