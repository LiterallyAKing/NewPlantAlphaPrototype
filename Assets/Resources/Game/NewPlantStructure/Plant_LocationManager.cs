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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
