using UnityEngine;
using System.Collections;

public class Plant_MasterManager : MonoBehaviour {

	//Game Managers
	public PlantManager plantmanager;
	public Transform playerlocation;

	//Managers, for this plant
	public Plant_LocationManager locmanager;
	public Plant_VisualsManager vizmanager;

	//TYPE
	public PlantType_Base planttypelogic;

	//ForAllPlantCalculations
	float speedmultiplier = 0;
	float growthtimer = 0;
	float growthdelay = 2.5f;


	void Start () {
		playerlocation = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (transform.position, playerlocation.position);

		//TODO: Make this a curve!
		if (dist > 7.5f) {
			speedmultiplier = 0.8f;
		} else {
			speedmultiplier = 7.5f - (6.7f * (dist / 7.5f));
		}


		growthtimer += (Time.deltaTime * speedmultiplier);
		if (growthtimer > growthdelay) {
			planttypelogic.PlantProcess ();
			growthtimer = 0f;
		}
	}

	public void Die(){
		if (locmanager.moveState == Plant_LocationManager.MoveState.inground) {
			locmanager.Uproot();
			plantmanager.plants.Remove (this.gameObject);
			Destroy (this.gameObject);
		}
	}
}
