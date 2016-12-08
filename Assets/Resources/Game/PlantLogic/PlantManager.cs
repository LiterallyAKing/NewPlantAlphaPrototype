using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlantManager : MonoBehaviour {

	public Plant_MasterManager[] plantPrefabs;
	public List<GameObject> plants = new List<GameObject> ();

	public GridManager gridman;
	Timer checkTimer;
	int x_length = 0;
	int z_length = 0;

	// Use this for initialization
	void Start () {
		x_length = gridman.width;
		z_length = gridman.height;


//		CreatePlant (0, new GridCoordinates (1, 1));
//		CreatePlant (0, new GridCoordinates (1, 0));
//		CreatePlant (0, new GridCoordinates (1, 2));
//		CreatePlant (0, new GridCoordinates (2, 2));
//		CreatePlant (0, new GridCoordinates (3, 2));
//

		for (int i = 0; i < gridman.width; i++) {
			for (int j = 0; j < gridman.height; j++) {
				if (Random.value < 0.15f) {
					CreatePlant (typeof(PlantType_Weed), new GridCoordinates (i, j));
				}
			}
		}
//		for (int i = 0; i < gridman.width; i++) {
//			for (int j = 0; j < gridman.height; j++) {
//				if (Random.value < 0.03f) {
//					CreatePlant (1, new GridCoordinates (i, j));
//				}
//			}
//		}

		}
	
	// Update is called once per frame
	void Update () {
	}

//
//	public void CreatePlant(int index, GridCoordinates coord){
//		if (index + 1 <= plantPrefabs.Length) {
//			Vector3 pos;
//			pos.x = coord.X * GridMetrics.innerRadius;
//			pos.y = 0f;
//			pos.z = coord.Z * GridMetrics.innerRadius;
//			if (!(gridman.GetCell (coord).plantincell != null)) {
//				Plant_MasterManager newplant = Instantiate<Plant_MasterManager> (plantPrefabs [index]);
//				plants.Add (newplant.gameObject);
//				newplant.transform.SetParent (transform, false);
//				newplant.plantmanager = this;
//				//newplant.myPlantIndex = index;
//				newplant.transform.localPosition = pos;
//				newplant.locmanager.mycoord = coord;
//				newplant.locmanager.mycell = gridman.GetCell (coord);
//				newplant.locmanager.mycellStats = newplant.locmanager.mycell.GetComponent<GridStats> ();
//				gridman.GetCell (coord).plantincell = newplant.locmanager;
//			}
//		}
//	}
//
	public void CreatePlant(System.Type type, GridCoordinates coord){
		if (!gridman.GetCell (coord).occupied) {
			Plant_MasterManager toinstantiate = null;
			foreach (Plant_MasterManager prefab in plantPrefabs) {
				if (prefab.planttypelogic.GetType () == type) {
					toinstantiate = prefab;
				}
			}

			Plant_MasterManager newplant = Instantiate<Plant_MasterManager> (toinstantiate);
			newplant.transform.SetParent (this.transform, false);
			newplant.plantmanager = this;
			newplant.locmanager.SetMyLocation (coord);

			plants.Add (newplant.gameObject);


		}
	}




	public bool DoesCellContainPlant(GridCell cell) {
		return cell.occupied;
	}
	public bool DoesCellContainPlant(GridCoordinates coord) {
		bool toreturn = false;
		if (DoesCellContainPlant(gridman.GetCell(coord))) {
			toreturn = true;
		}
		return toreturn;
	}
	public bool DoesCellContainPlant(GridCell cell, PlantType_Base planttype) {
		bool toreturn = false;
		if (DoesCellContainPlant(cell)) {
			toreturn = cell.plantincell.GetComponent<PlantType_Base> ().GetType() == planttype.GetType();
		}
		return toreturn;
	}
	public bool DoesCellContainPlant(GridCoordinates coord, PlantType_Base planttype) {
		bool toreturn = false;
		GridCell celltocheck = gridman.GetCell (coord);
		toreturn = DoesCellContainPlant (celltocheck, planttype);
		return toreturn;
	}

	public int HowManyPlantsAroundCell(GridCell cell){
		int toreturn = 0;
		List<GridCell> cellstocheck;
		cellstocheck = cell.GetNeighbors ();
		for (int i = 0; i < cellstocheck.Count; i++) {
			if (DoesCellContainPlant (cellstocheck [i])) {
				toreturn++;
			}
		}
		return toreturn;
	}
	public int HowManyPlantsAroundCell(GridCoordinates coord){
		int toreturn = 0;
		GridCell celltocheck = gridman.GetCell (coord);
		toreturn = HowManyPlantsAroundCell (celltocheck);
		return toreturn;
	}
	public int HowManyPlantsAroundCell(GridCell cell, PlantType_Base planttype){
		int toreturn = 0;
		List<GridCell> cellstocheck;
		cellstocheck = cell.GetNeighbors ();
		for (int i = 0; i < cellstocheck.Count; i++) {
			if (DoesCellContainPlant (cellstocheck [i], planttype)) {
				toreturn++;
			}
		}
		return toreturn;
	}
	public int HowManyPlantsAroundCell(GridCoordinates coord, PlantType_Base planttype){
		int toreturn = 0;
		GridCell celltocheck = gridman.GetCell (coord);
		toreturn = HowManyPlantsAroundCell (celltocheck, planttype);
		return toreturn;
	}



}
