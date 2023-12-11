using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyStats stats;
    public Vector3 attackOffset;
    public float attackRange = 0.5f;
    public LayerMask attackMask;


    private void Start()
    {
        stats = GetComponent<EnemyStats>();
    }
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            if (colInfo.gameObject.tag == "Player")
            {
                colInfo.GetComponent<PlayerStats>().TakeDamage(stats.attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
