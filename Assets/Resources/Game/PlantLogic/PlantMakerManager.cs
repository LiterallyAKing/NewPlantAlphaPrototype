using UnityEngine;
using System.Collections;

public class PlantMakerManager : MonoBehaviour {

	private int chosenPlant = 0;
	public GridManager gridman;
	public PlantManager plantman;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlantChooseInput ();
	
	}

	void PlantChooseInput(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			chosenPlant = 1;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			chosenPlant = 2;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			chosenPlant = 3;
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			chosenPlant = 4;
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			chosenPlant = 5;
		}
	}

	public void MakePlant(GridCoordinates targcoord){
		if (chosenPlant > 0) {
			plantman.CreatePlant (chosenPlant - 1, targcoord);
		}
	}

}
