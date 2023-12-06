using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodOfWindAttack : MonoBehaviour
{
    private Animator anim;
    public PlayerStats stat;
    public Vector3 attack_01;
    public Vector3 attack_02;
    public Vector3 attack_03;
    public float attackRange1 = 0.5f;
    public float attackRange2 = 0.5f;
    public float attackRange3 = 0.5f;
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

    private void Attack1()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attack_01.x;
        pos += transform.up * attack_01.y;
        //detect enemies
        Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(pos, attackRange1, enemyLayers);

        //deal damage
        foreach (Collider2D enemy in hittedEnemies)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(stat.attackDamage);
        }
    }
    private void Attack2()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attack_02.x;
        pos += transform.up * attack_02.y;
        //detect enemies
        Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(pos, attackRange2, enemyLayers);

        //deal damage
        foreach (Collider2D enemy in hittedEnemies)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(stat.attackDamage);
        }
    }
    private void Attack3()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attack_03.x;
        pos += transform.up * attack_03.y;
        //detect enemies
        Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(pos, attackRange3, enemyLayers);

        //deal damage
        foreach (Collider2D enemy in hittedEnemies)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(stat.attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos1 = transform.position;
        pos1 += transform.right * attack_01.x;
        pos1 += transform.up * attack_01.y;
        Gizmos.DrawWireSphere(pos1, attackRange1);

        Vector3 pos2 = transform.position;
        pos2 += transform.right * attack_02.x;
        pos2 += transform.up * attack_02.y;
        Gizmos.DrawWireSphere(pos2, attackRange2);

        Vector3 pos3 = transform.position;
        pos3 += transform.right * attack_03.x;
        pos3 += transform.up * attack_03.y;
        Gizmos.DrawWireSphere(pos3, attackRange3);
    }
    public void Combo()
    {
        if (Input.GetKeyDown(KeyCode.M) && !isAtk)
        {
            isAtk = true;
            anim.SetTrigger("Attack" + comboIndex);
            switch (comboIndex)
            {
                case 1:
                    Attack1(); 
                    break;
                case 2: 
                    Attack2();
                    break;
                case 3:
                    Attack3();
                    break;
            }
        }
    }
    public void StartCombo()
    {
        isAtk = false;
        if (comboIndex < 3)
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
