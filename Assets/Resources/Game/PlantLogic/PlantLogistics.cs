using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlantLogistics : MonoBehaviour {

	public GridCoordinates mycoord;
	public GridCell mycell;
	public GridStats mycellStats;
	[HideInInspector] public PlantManager myplantman;
	[HideInInspector] public int myPlantIndex;
	private Timer tick_timer;

	void Start () {

	}

	void Update () {

	}

//	public void Reproduce(int range){
//		List<GridCell> growtargets = new List<GridCell> ();
//		if (range >= 1) {
//			for (int i = 0; i < mycell.neighbors.Length; i++) {
//				if (mycell.neighbors [i] != null) {
//					if (!(mycell.neighbors [i].plantincell != null)) {
//						growtargets.Add (mycell.neighbors [i]);	
//					}
//				}
//			}
//		}
//		if (range >= 2) {
//			for (int i = 0; i < mycell.farneighbors.Length; i++) {
//				if (mycell.farneighbors [i] != null) {
//					if (!(mycell.farneighbors [i].plantincell != null)) {
//						growtargets.Add (mycell.farneighbors [i]);	
//					}
//				}
//			}
//		}
//		if (growtargets.Count > 0) {
//			int rand = Random.Range (0, growtargets.Count - 1);
//			GridCell target = growtargets [rand];
//			myplantman.CreatePlant (myPlantIndex, target.coordinates);
//		}
//	}
		

}
