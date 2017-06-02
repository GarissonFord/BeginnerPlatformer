﻿using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour 
{
	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = true;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;

	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2d> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//1 << LayerMask....is basically a way of saying "We are only seeing if groundCheck is touching "Ground"
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (Input.GetButtonDown ("Jump") && grounded) 
		{
			jump = true;
		}
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");
		//Stops from getting a negative speed and screwing up calculations
		anim.SetFloat ("Speed", Mathf.Abs (h));

		//We have a speed cap 
		if (h * rb2d.velocity.x < maxSpeed) 
		{
			rb2d.AddForce (Vector2.right * h * moveForce);
		}

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) 
		{
			//Mathf.Sign returns -1 or 1 depending on the sign of the input
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x));
		}
	}

	//This is the kind of function I could have used previously
	void Flip()
	{
		facingRight = !facingRight;
		//what
		Vector3 theScale = transform.localScale;
		//ohhh
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}