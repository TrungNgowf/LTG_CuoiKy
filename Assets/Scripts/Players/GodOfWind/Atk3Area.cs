using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atk3Area : MonoBehaviour
{
    private PlayerStats stats;
    private void Start()
    {
        stats = GetComponentInParent<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
            {
                collision.gameObject.GetComponent<EnemyStats>().TakeDamage(stats.attackDamage*1.2f);
            }
        }
    }
}
