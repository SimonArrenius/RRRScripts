using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class cockroachAttack : MonoBehaviour
{
    //private bool isAttacking = false;
    [SerializeField] GameObject wrench;
    [SerializeField] private Sprite attackSprite;
    [SerializeField] private Sprite originalSprite;
    
    [SerializeField] float timeBetweenAttack = 1;
    private float attackTimer = 0;
    public bool attackIsReady = true;

    private void Update()
    {
        
        if (attackIsReady)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                attackTimer = Time.time;
                attackIsReady = false;
                wrench.SetActive(true);
                GetComponent<SpriteRenderer>().sprite = attackSprite;
                StartCoroutine(CancelAttack(timeBetweenAttack));
            }
        }
    }

    private IEnumerator CancelAttack(float delay)
    {
        yield return new WaitForSeconds(delay);
        wrench.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = originalSprite;

        attackIsReady = true;
        
    }

}
