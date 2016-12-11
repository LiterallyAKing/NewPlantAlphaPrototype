using UnityEngine;
using System.Collections;

public class Plant_LocationManager : MonoBehaviour {



	//Managers
	public Plant_MasterManager mymanager;

	//Location
	public enum MoveState {inground, carried}
	public MoveState moveState = MoveState.inground;
	public GridCoordinates mycoord;
	public GridCell mycell;
	public GridStats mycellStats;


	[HideInInspector] public int LightMod = 0, WaterMod = 0, HeatMod = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void SetMyGridLocation(GridCoordinates coord){
		if (!mymanager.plantmanager.gridman.GetCell(coord).occupied){
			Vector3 pos;
			pos.x = coord.X * GridMetrics.innerRadius;
			pos.y = 0f;
			pos.z = coord.Z * GridMetrics.innerRadius;
			if (this.transform.parent != mymanager.plantmanager.transform) {
				this.transform.parent = mymanager.plantmanager.transform;
			}

			transform.localPosition = pos;
			mycoord = coord;

			mycell = mymanager.plantmanager.gridman.GetCell (coord);
			mycellStats = mycell.GetComponent<GridStats> ();
			mycell.plantincell = this;
			moveState = MoveState.inground;


			//mymanager.vizmanager.SetSortOrder (coord.Z);
			mymanager.vizmanager.SetSortOrder (0);
		}
	}

	public void Uproot(){
		if (moveState == MoveState.inground) {
			mymanager.vizmanager.SetSortOrder (-1);
			mycell.plantincell = null;
			mycell = null;
			mycellStats = null;
			moveState = MoveState.carried;
		}
	}


}
