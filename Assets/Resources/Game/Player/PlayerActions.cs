using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour {

	public PlayerMovement mymove;
	public GridManager gridman;
	bool clicked = false;
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
		clicked = true;
		menuLoc = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			Vector3 position = hit.point;

			GridCell cell = CellAtPosition (position);

			cell.gameObject.SetActive (false);
		}
	}



	GridCell CellAtPosition(Vector3 pos){
		GridCoordinates coordinates = GridCoordinates.FromPosition (pos);
		GridCell cell = gridman.GetCell (coordinates);
		return cell;
	}

	void OnGUI() {
		if (clicked) {
			if (GUI.Button(new Rect(menuLoc.x, Screen.height- menuLoc.y, 150, 100), "I am a button"))
				print("You clicked the button!");
			
		}

	}

}
