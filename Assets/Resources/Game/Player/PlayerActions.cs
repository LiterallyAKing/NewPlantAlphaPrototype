﻿using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour {

	public PlayerMovement mymove;
	public GridManager gridman;
	public PlantInventory inventory;
	bool clicked = false;
	GridCoordinates clickedcoord;
	Vector2 menuLoc = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(1)) {


			HandleInput ();
		}
	}

	void HandleInput () {
		
		menuLoc = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			Vector3 position = hit.point;

			GridCell cell = CellAtPosition (position);
			if (cell != null) {
				clicked = true;
				clickedcoord = cell.coordinates;
			}
		}
	}



	GridCell CellAtPosition(Vector3 pos){
		GridCoordinates coordinates = GridCoordinates.FromPosition (pos);
		GridCell cell = gridman.GetCell (coordinates);
		return cell;
	}

	void OnGUI() {
		if (clicked) {
			if (inventory.carrying == false) {
				if (gridman.GetCell (clickedcoord).occupied == true) {
					if (GUI.Button (new Rect (menuLoc.x, Screen.height - menuLoc.y, 75, 50), "Pick Up")) {
						inventory.Pickup (gridman.GetCell (clickedcoord));
						clicked = false;
					}
				}
			} else {
				if (gridman.GetCell (clickedcoord).occupied == false) {
					if (GUI.Button (new Rect (menuLoc.x, Screen.height - menuLoc.y, 75, 50), "Plant")) {
						inventory.PutDown (gridman.GetCell (clickedcoord));
						clicked = false;
					}
				}
			}
		}
	}

}
