using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLayout : MonoBehaviour 
{
    public enum Type { Grid, Pyramid }
    public Type type = Type.Grid;

    public Brick[] brickPrefabs = null;

    [Space]
    [Header("Grid Options")]
    public int bricksWide = 12;
    public bool offsetRows = false;

    private float brickWidth = 0;
    private float brickHeight = 0;

    void Awake()
    {
        brickWidth = brickPrefabs[0].width;
        brickHeight = brickPrefabs[0].height;
    }//Awake

    void Start () 
	{
        if (type == Type.Grid)
            MakeBricksGrid();
        else
            MakeBricksPyramid();
	}//Start

    void MakeBricksGrid()
    {
        //Make the parent object the center of the brick grid
        float startX = transform.position.x - ((bricksWide - 1) * brickWidth) / 2;

        //Start at the parent object's y pos
        float startY = transform.position.y;

        //If we're offsetting rows, move the grid left so it stays centered
        if (offsetRows)
            startX -= brickWidth / 4;

        //Grid is always as tall as there are # of bricks in the prefab list        
        for (int y = 0; y < brickPrefabs.Length; y++)
        {
            //If we're offsetting rows, offset every even-numbered row by half the brick width
            float rowOffset = offsetRows && !(y % 2 == 0) ? brickWidth / 2 : 0;

            //Place all the bricks in a line
            for (int x = 0; x < bricksWide; x++)
                MakeNewBrick(y, new Vector3(startX + x* brickWidth + rowOffset, startY - y * brickHeight));
        }//for
    }//MakeBricksGrid

    void MakeBricksPyramid()
    {
        //Start centered on the parent object
        float startX = transform.position.x;
        float startY = transform.position.y;

        for (int y = 0; y < brickPrefabs.Length; y++)
        {
            //Every row we go down has one extra brick in it
            //And is spaced out so it's centered and has a brick-width
            //In between every brick
            for (int x = 0; x < y+1; x++)
                MakeNewBrick(y, new Vector3(startX + x * brickWidth * 2, startY - y * brickHeight));

            //Move the start point left for every row we go down
            startX -= brickWidth;
        }//for
    }//MakeBricksGrid


    void MakeNewBrick(int type, Vector3 pos)
    {
        Instantiate<Brick>(brickPrefabs[type], pos, transform.rotation, transform);
    }//MakeNewBrick
	
}//BrickLayout