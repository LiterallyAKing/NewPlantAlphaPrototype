using UnityEngine;
using System.Collections;

public class PlantType_Base : MonoBehaviour {


	[HideInInspector] public Plant_MasterManager mymastermanager;
	[HideInInspector] public Plant_LocationManager locmanager;
	[HideInInspector] public Plant_VisualsManager vizman;

	public virtual void Start () {
		mymastermanager = GetComponent<Plant_MasterManager> ();
		locmanager = mymastermanager.locmanager;
		vizman = mymastermanager.vizmanager;
	}

	public virtual void PlantProcess(){
		
	}
}
