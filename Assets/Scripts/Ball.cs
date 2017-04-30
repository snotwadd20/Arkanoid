using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{
	public float speed = 100;
	private Rigidbody2D rb2d = null;

	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}//Awake

	void Start () 
	{
		rb2d.velocity = Vector2.up * speed;
	}//Awake

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.GetComponent<Racket>())
		{
			float x = HitFactor(transform.position, coll.transform.position, coll.collider.bounds.size.x);
			Vector2 dir = new Vector2(x, 1).normalized;
			rb2d.velocity = dir * speed;
		}//if
	}//OnCollisionEnter2D

	float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
	{
		// 1  -0.5  0  0.5   1  <- x value
		// ===================  <- racket
	
		return (ballPos.x - racketPos.x) / racketWidth;
	}//float

	void Update () 
	{
		
	}//Update
}//
