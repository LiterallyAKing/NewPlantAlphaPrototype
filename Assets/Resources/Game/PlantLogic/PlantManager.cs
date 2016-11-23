using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlantManager : MonoBehaviour {

	public PlantLogistics[] plantPrefabs;
	public List<GameObject> plants = new List<GameObject> ();

	public GridManager gridman;
	Timer checkTimer;
	int x_length = 0;
	int z_length = 0;

	// Use this for initialization
	void Start () {
		x_length = gridman.width;
		z_length = gridman.height;


		CreatePlant (0, new GridCoordinates (1, 1));

		}
	
	// Update is called once per frame
	void Update () {




	}


	public void CreatePlant(int index, GridCoordinates coord){
		if (index + 1 <= plantPrefabs.Length) {
			Vector3 pos;
			pos.x = coord.X * GridMetrics.innerRadius;
			pos.y = 0f;
			pos.z = coord.Z * GridMetrics.innerRadius;
			if (!(gridman.GetCell (coord).plantincell != null)) {
				PlantLogistics newplant = Instantiate<PlantLogistics> (plantPrefabs [index]);
				plants.Add (newplant.gameObject);
				newplant.transform.SetParent (transform, false);
				newplant.myplantman = this;
				newplant.myPlantIndex = index;
				newplant.transform.localPosition = pos;
				newplant.mycoord = coord;
				newplant.mycell = gridman.GetCell (coord);
				newplant.mycellStats = newplant.mycell.GetComponent<GridStats> ();
				gridman.GetCell (coord).plantincell = newplant;
			}
		}
	}

	int CountPlant(int index){
		int toreturn = 0;
		for (int i = 0; i < plants.Count - 1; i++) {
			if (plants [i].GetComponent<PlantLogistics> ().myPlantIndex == index) {
				toreturn++;
			}
		}
		return toreturn;
	}


}
