using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour 
{
	public float speed = 4;
	private Rigidbody2D rb2d = null;

	private float inputH = 0;

	void Awake () 
	{
		rb2d = GetComponent<Rigidbody2D>();
	}//Awake


	void Update()
	{
		inputH = Input.GetAxisRaw("Horizontal");
		//print(inputH);
	}//Update


	void FixedUpdate () 
	{
		rb2d.velocity = inputH * Vector2.right * speed * Time.deltaTime;
	}//Update
}//
