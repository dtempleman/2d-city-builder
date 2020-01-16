using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	public static WorldManager Instance { get; protected set;}

	bool tile_change;

	public World World { get; protected set;}

	// the dimentions of the world in boards
	public int boards_wide = 10;
	public int boards_high = 10; 
	// the size of one square edge of the bard in tiles
	public int board_size = 10;



	// the collection of the GameObjects of tiles
	public Dictionary<Vector2, GameObject> gameObjects { get; protected set;}

	public Sprite tile_sprite;
	public Texture2D map_texture;

	// Use this for initialization
	void Start () {
		if (Instance != null) {
			// error there should only ever be 1 Worldmanager
		}
		Instance = this;

		gameObjects = new Dictionary<Vector2,GameObject> ();

		World = new World (boards_wide, boards_high, board_size);
		InitializeWorld ();

	}
	
	// Update is called once per frame
	void Update () {
		if (tile_change) {
			UpdateWorld ();
			tile_change = false;
		}
	}

	void InitializeWorld(){
	
		for (int i = 0; i < boards_wide*board_size; i++) {
			for (int j = 0; j < boards_high*board_size; j++) {
				InitializeTile(i, j);
			}
		}
	}
		
	void InitializeTile(int x, int y){
		Tile tile = World .GetTileAt (x, y);
		GameObject tile_go = new GameObject ("Tile[" + x + "," + y + "]");
		tile_go.transform.position = new Vector3 (x, y, 0);

		//this is going to get very messy
		tile_go.transform.SetParent (this.transform);

		SpriteRenderer spriteRenderer = tile_go.AddComponent<SpriteRenderer> ();
		spriteRenderer.sprite = tile_sprite;

		tile.SetElevation (Random.Range (0, 10));
		byte color = (byte)(tile.Elevation()*25);

		spriteRenderer.color = new Color32 (color, color, color, 255);
		gameObjects.Add (new Vector2 (x, y), tile_go);
	}

	public void SetElevationOfTileAt(int x, int y, int elevation){
		Tile t = World.GetTileAt (x, y);
		t.SetElevation (elevation);
		tile_change = true;

	}

	//updates the visuals of the world to reflect the data
	void UpdateWorld(){
		for (int i = 0; i < boards_wide*board_size; i++) {
			for (int j = 0; j < boards_high*board_size; j++) {
				UpdateTile (i, j);
			}
		}
	}

	// updates the visuals of the tile to refelect the data
	void UpdateTile(int x, int y){
		Tile t = World.GetTileAt (x, y);
		GameObject go = gameObjects [new Vector2 (x, y)];
		SpriteRenderer _sr = go.GetComponent<SpriteRenderer> ();
		_sr.color = new Color32 ((byte)t.Elevation(), (byte)t.Elevation(), (byte)t.Elevation(), 255);

	}


	

}
