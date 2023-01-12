using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class cockroachMovement : MonoBehaviour
{

    public Animator animator;
    
    [Header("Is your character facing right before runtime? If yes, check box")]
    public bool facingRight;

    private float moveDirection;
    
    float horizontal;
    float vertical;
    
    private Rigidbody2D rb;
    
    public float horizontalValue;
    public float moveSpeed = 10.0f;
    public float stunDuration;

    private bool isStun = false;
    
    private Vector2 movementDirection; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    void Update()
    {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            float verticalInput = Input.GetAxisRaw("Vertical");
            if (isStun)
            {
                horizontalInput = 0;
                verticalInput = 0;
            }
            
            move(horizontalInput);
            

                if (horizontalInput == 0)
            {
                animator.SetFloat("Speed", Mathf.Abs(verticalInput));
            }

            else
            {
                animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
            }

            movementDirection = new Vector2(horizontalInput, verticalInput);
            float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
            movementDirection.Normalize();

            //transform.Translate(movementDirection * moveSpeed * inputMagnitude * Time.deltaTime, Space.World);

            // use this for the wrong way
            //wrongWayToFlip();

            // use this for a better way
            properFlip();
    }

	private void FixedUpdate()
	{
        rb.velocity = movementDirection * moveSpeed;       
    }

    void move(float horizontalInput)
    {
        horizontalValue = horizontalInput * moveSpeed * Time.deltaTime;
        //rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
        //transform.Translate(new Vector3()
    }

    void properFlip()
    {
        if((horizontalValue < 0 && facingRight) || (horizontalValue > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    void wrongWayToFlip()
    {
        if ((horizontalValue < 0 && facingRight) || (horizontalValue > 0 && !facingRight))
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        } 
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero; 
    }

	private void OnEnable()
	{
        animator.SetBool("Attacking", false);
	}

    private IEnumerator StartStun()
    {
        yield return new WaitForSeconds(stunDuration);
        isStun = false;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Projectile"))
        {
            Debug.Log("Stunned");
            isStun = true;
            StartCoroutine("StartStun");
            animator.SetBool("isStunned", true);
        }
    }
}