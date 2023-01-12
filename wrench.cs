using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private cockroach player;
    private float xForce = 500;

    private void Awake()
    {
        player = GetComponentInParent<cockroach>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        
        //Debug.Log(obj);
        if (obj.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = obj.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(gameObject, player.GetDamage(), xForce);
            
        }
    }
}
