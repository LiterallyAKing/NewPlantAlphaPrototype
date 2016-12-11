using UnityEngine;
using System.Collections;

public class PlantInventory : MonoBehaviour {

	public bool carrying {
		get { return carriedplant != null; }
	}

	public Plant_LocationManager carriedplant;
	public Transform carryspot;


	public void Pickup(GridCell fromcell){
		if (fromcell.occupied) {
			carriedplant = fromcell.plantincell;
			carriedplant.transform.parent = carryspot;
			carriedplant.transform.position = carryspot.position;
			carriedplant.Uproot ();

		}
	}
}
