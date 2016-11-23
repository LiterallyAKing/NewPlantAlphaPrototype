using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour {

	public PlayerMovement mymove;
	string currentAction = "water";
	public float waterAmount = 0;
	public float nutrientAmount = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetMouseButtonDown(1)) {
//			if (currentAction == "water") {
//				Water (mymove.currentCell);
//			} else if (currentAction == "nutrient") {
//				Nutrient (mymove.currentCell);
//			} else if (currentAction == "trim") {
//				Trim (mymove.currentCell);
//			}
//		}
	}

	public void SetAction(string action){
		currentAction = action;
	}

	public void DoAction(string action){
		SetAction (action);
		if (currentAction == "water") {
			Water (mymove.currentCell);
		} else if (currentAction == "nutrient") {
			Nutrient (mymove.currentCell);
		} else if (currentAction == "trim") {
			Trim (mymove.currentCell);
		}
	}

	void Water(GridCell cell){
//		cell.GetComponent<GridResources> ().ChangeResourceAmt (ResourceType.B, waterAmount);
//		for (int i = 0; i < cell.neighbors.Length; i++) {
//			if (cell.neighbors [i] != null) {
//				cell.neighbors [i].GetComponent<GridResources> ().ChangeResourceAmt (ResourceType.B, waterAmount);
//			}
//		}
	}

	void Nutrient(GridCell cell){
		//cell.GetComponent<GridResources> ().ChangeResourceAmt (ResourceType.G, nutrientAmount);
	}

	void Trim(GridCell cell){
		if (cell.plantincell != null) {
			Destroy (cell.plantincell.gameObject);
			cell.plantincell = null;
		}
	}


}
