using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Tile t = new Tile (0, 0, new Board(10, new Vector2 (0,0), new World (1,1,10)));
		Debug.Log (t);
		Board b = new Board (10, new Vector2 (0, 0), new World (1, 1, 10));
		Debug.Log (b);
		World w = new World (10, 10, 10);


		Debug.Log (w);
		Debug.Log (w.GetTileAt(0,0));
		Debug.Log (w.GetTileAt(99,99));
		Debug.Log (w.GetTileAt(0,99));
		Debug.Log (w.GetTileAt(99,0));

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
