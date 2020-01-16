using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	Tile IncreaseElevationWithRadius(Vector3 pos){
		int x = Mathf.FloorToInt (pos.x);
		int y = Mathf.FloorToInt (pos.y); 
		return WorldManager.Instance.World.GetTileAt(x,y);
	}


}

