using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cockroach : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    public int GetDamage()
    {
        return damage;
    }

    private void Attacking()
	{
        GetComponentInParent<cockroachMovement>().enabled = false; 
	}

    private void FinishedAttack()
	{
        GetComponentInParent<cockroachMovement>().enabled = true; 
	}
}
