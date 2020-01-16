using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {
	// the 2d coordinates of the tile
	private int x;
	private int y;
	// the elevations of the tile (1-10)
	private int elevation;
	// if a tile is "walkable", the pathfinding can use it for the path
	private bool walkable;
	//the board that the tile is a part of
	private Board board;

	// creates a tile with the coordinates of x,y
	// if walkable is not set it will default to true
	public Tile (int x, int y, Board board, bool walkable = true){
		this.x = x;
		this.y = y;
		this.elevation = 0;
		this.board = board;
		this.walkable = walkable;
	
	}

	//returns a description of the tile
	public override string ToString(){
		if (walkable)
			return "tile[" + this.x + "," + this.y + "] with elevation " + elevation + " of board "+ board + " is walkable.";
		return "tile[" + this.x + "," + this.y + "] with elevation " + elevation + " is not walkable.";
	}

	public void SetElevation (int e){
		this.elevation = e;
	}

	public bool IsWalkable(){ return this.walkable; }

	public Board ParentBoard(){ return this.board; }

	public World ParentWorld() { return this.board.ParentWorld(); } 

	public int X(){ return this.x; }

	public int Y(){ return this.y; }

	public int Elevation() { return this.elevation; }

	//returns the x,y coordinates in a Vector2
	public Vector2 Coordinates(){
		return new Vector2(this.x, this.y);
	}
}
