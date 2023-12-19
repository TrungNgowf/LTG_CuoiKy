using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public PlayerStats stat;
    public Vector3 attack_01;
    public Vector3 attack_02;
    //public Vector3 attack_03;
    public float attackRange1 = 0.5f;
    public float attackRange2 = 0.5f;
    //public float attackRange3 = 0.5f;
    public LayerMask enemyLayers;
    public int comboIndex = 1;
    public bool isAtk;
    public Collider2D _atk3Area;
    public Collider2D _specAtkArea;


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
        SpecialAttack();
    }

    private void Attack1()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attack_01.x*transform.localScale.x;
        pos += transform.up * attack_01.y;
        //detect enemies
        Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(pos, attackRange1, enemyLayers);
        if (hittedEnemies.Length > 0)
        {
            stat.GainMana(5);
        }
        //deal damage
        foreach (Collider2D enemy in hittedEnemies)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(stat.attackDamage);
        }
    }
    private void Attack2()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attack_02.x * transform.localScale.x;
        pos += transform.up * attack_02.y;
        //detect enemies
        Collider2D[] hittedEnemies = Physics2D.OverlapCircleAll(pos, attackRange2, enemyLayers);
        if (hittedEnemies.Length > 0)
        {
            stat.GainMana(5);
        }
        //deal damage
        foreach (Collider2D enemy in hittedEnemies)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(stat.attackDamage*1.1f);
        }
    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos1 = transform.position;
        pos1 += transform.right * attack_01.x * transform.localScale.x;
        pos1 += transform.up * attack_01.y;
        Gizmos.DrawWireSphere(pos1, attackRange1);

        Vector3 pos2 = transform.position;
        pos2 += transform.right * attack_02.x * transform.localScale.x;
        pos2 += transform.up * attack_02.y;
        Gizmos.DrawWireSphere(pos2, attackRange2);

    }
    private void SpecialAttack()
    {
        if (Input.GetKeyDown(KeyCode.X) && stat.checkMaxMana())
        {
            anim.SetTrigger("SpAtk");
            stat.setCurrentMana(0);
        }
    }
    public void Combo()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isAtk)
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
                    //Attack3();
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
    public void setAtk3AreaActive()
    {
        _atk3Area.GetComponent<Atk3Area>().gameObject.SetActive(true);
    }
    public void setAtk3AreaInActive()
    {
        _atk3Area.GetComponent<Atk3Area>().gameObject.SetActive(false);
    }
    public void setSpecialAtkAreaActive()
    {
        _specAtkArea.GetComponent<SpecialAttackArea>().gameObject.SetActive(true);
    }
    public void setSpecialAtkAreaInActive()
    {
        _specAtkArea.GetComponent<SpecialAttackArea>().gameObject.SetActive(false);
    }
    public void resetWhenGetHit()
    {
        comboIndex = 1;
        setAtk3AreaInActive();
        setSpecialAtkAreaInActive();
    }
}
