using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DropItems : MonoBehaviour
{
    private Rigidbody2D rig;
    private float dropForce = 4;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>()) ;
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Players"))
        {
            if (gameObject.name == "ManaGem(Clone)")
            {
                collision.gameObject.GetComponent<PlayerStats>().GainMana(10);
            }
            if (gameObject.name == "HeartGem(Clone)")
            {
                collision.gameObject.GetComponent<PlayerStats>().GainHealth(30);
            }
            Destroy(gameObject);
        }
    }
}
