using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntressAttack : MonoBehaviour
{
    private Animator anim;
    private HuntressStats stat;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    float nextAttackTime = 0;


    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        stat = GetComponent<HuntressStats>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Attack();
                nextAttackTime = Time.time + 1f / stat.attackSpeed;
            }
        }

    }

    private void Attack()
    {
        anim.SetTrigger("Attack1");

        ////detect enemies
        //Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        ////deal damage
        //foreach (Collider2D enemy in hittedEnemies)
        //{
        //}
    }
    //private void OnDrawGizmos()
    //{
    //    if (attackPoint == null) return;
    //    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    //}
}
