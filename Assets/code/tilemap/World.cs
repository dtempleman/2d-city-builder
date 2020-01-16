using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a world is made up of multiple boards of tiles
public class World {

	// the number of boards wide the world is
	private int boards_wide;
	// the number of boards heigh it the world is
	private int boards_high;
	// the dimentions of the board (square)
	private int board_size;
	// collection of all the boards with their width/height as location
	public Dictionary<Vector2, Board> boardData { get; protected set;}

	public World (int boards_wide, int boards_high, int board_size){
		this.boards_wide = boards_wide;
		this.boards_high = boards_high;
		this.board_size = board_size;
		this.boardData = new Dictionary<Vector2, Board> ();


		for (int i = 0; i < boards_wide; i++) {
			for (int j = 0; j < boards_high; j++) {
				CreateBoard(new Vector2 (i,j));
			}
		}

		Debug.Log ("Success! created " + this);

	}
		
	public Board GetBoardAt(Vector2 pos){	
		// if the board is not in boardData crate a new board
		if (boardData.ContainsKey (pos) == false) {
			return CreateBoard (pos);
		} else {
			Board board = boardData [pos];
			return board;
		}
	}
		
	// returns a new board and adds it to boardData
	private Board CreateBoard(Vector2 pos){
		Board board = new Board (board_size, pos, this);
		boardData.Add (pos, board);
		return board;
	}


	// returns the tile at (x,y) in world coordinates
	public Tile GetTileAt(int x, int y){
		int world_x = (int) x / board_size;
		int world_y = (int) y / board_size;
	
		int board_x = x % board_size;
		int board_y = y % board_size;

		if(boardData.ContainsKey(new Vector2 (world_x, world_y))){
			return  boardData [new Vector2 (world_x, world_y)].GetTileAt (board_x, board_y);
		}
			//throw some "tile does not exist" exceprion
			return null;
	}

	//returns a description of the world and its dimentions
	public override string ToString(){
		return "World of " + boards_wide * boards_high + " boards and " + boards_wide * boards_high * board_size + " tiles.";
	}
}
