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
    public int comboIndex = 1;
    public bool isAtk;
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
        Combo();
    }

    private void Attack()
    {
        //detect enemies
        Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(attackPoint.position, stat.attackRange, enemyLayers);

        //deal damage
        foreach (Collider2D enemy in hittedEnemies)
        {
        }
    }
    private void OnDrawGizmos()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, stat.attackRange);
    }
    public void Combo()
    {
        if (Input.GetKeyDown(KeyCode.M) && !isAtk)
        {
            isAtk = true;
            anim.SetTrigger("Attack" + comboIndex);
        }
    }
    public void StartCombo()
    {
        isAtk = false;
        if (comboIndex < 2)
        {
            comboIndex++;
        }
    }
    public void FinishAnim()
    {
        isAtk = false;
        comboIndex = 1;
    }
}
