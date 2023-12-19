using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToDead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if(collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerStats>().setCurrentHealth(0);
            }
        }
    }
}
