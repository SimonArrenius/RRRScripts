using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	//private bool isAttacking = false;    

	//[SerializeField] float timeBetweenAttack = 1;
	public bool attackIsReady = true;

	private Animator animator;	

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && attackIsReady)
		{
			attackIsReady = false; 
			Attack();
		}
	}

	private void Attack()
	{		
		animator.SetBool("Attacking", true);		
		// StartCoroutine(CancelAttack(timeBetweenAttack));
	}

	private void FinishedAttack()
	{
		animator.enabled = true;
		attackIsReady = true;
		animator.SetBool("Attacking", false);			
	}
	
	/* private IEnumerator CancelAttack(float delay)
	 {
		 yield return new WaitForSeconds(delay);
		 animator.SetBool("Attacking", false);
		 attackIsReady = true;

	 }*/

}
