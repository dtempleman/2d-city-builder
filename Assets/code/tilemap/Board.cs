using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a board is made up of multiple tiles
public class Board{

	private Tile[,] tiles;

	private World world;

	private Vector2 position;


	public Board (int board_size, Vector2 position, World world){
		this.world = world;
		this.position = position;

		tiles = new Tile[board_size, board_size];

		for (int i = 0; i < board_size; i++) {
			for (int j = 0; j < board_size; j++) {
				tiles [i, j] = new Tile (i, j, this);
			}
		}
	}

	// returns the tile at (x,y) in board coordinates
	public Tile GetTileAt(int x, int y){
		return tiles [x, y];
	}

	//returns a description of the board and its board #
	public override string ToString(){
		return "Board [" + position.x + "," + position.y + "]";
	}

	public World ParentWorld() { return this.world; }

}
