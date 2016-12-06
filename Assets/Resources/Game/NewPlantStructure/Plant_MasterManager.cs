using UnityEngine;
using System.Collections;

public class Plant_MasterManager : MonoBehaviour {

	//Game Managers
	public PlantManager plantmanager;

	//Managers, for this plant
	public Plant_LocationManager locmanager;
	public Plant_VisualsManager vizmanager;

	//TYPE
	public PlantType_Base planttypelogic;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
