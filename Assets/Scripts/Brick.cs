using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour 
{
    void OnCollisionEnter2D(Collision2D coll)
	{
		Destroy(gameObject);
	}//OnCollisionEnter2D

    //ALL THIS IS BONUS CODE SO WE KNOW HOW WIDE/TALL THE BRICKS ARE

    public SpriteRenderer spriteRenderer = null;

    public float width { get { SRValid(); return spriteRenderer.bounds.extents.x * 2; } }
    public float height { get { SRValid(); return spriteRenderer.bounds.extents.y * 2; } }

    void Awake()
    {
        SRValid();
    }//Awake

    void SRValid()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }//
}//
