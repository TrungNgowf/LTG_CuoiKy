using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntressAttack : MonoBehaviour
{
    private Animator anim;
    public PlayerStats stat;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public int comboIndex = 1;
    public bool isAtk;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        stat = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    private void Update()
    {
        Combo();
    }

    private void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x * transform.localScale.x;
        pos += transform.up * attackOffset.y;
        //detect enemies
        Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(pos, attackRange, enemyLayers);

        //deal damage
        foreach (Collider2D enemy in hittedEnemies)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(stat.attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x * transform.localScale.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
    public void Combo()
    {
        if (Input.GetKeyDown(KeyCode.M) && !isAtk)
        {
            isAtk = true;
            anim.SetTrigger("Attack" + comboIndex);
            Attack();
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
    public void setAttackActive()
    {
        isAtk = false;
    }
}
