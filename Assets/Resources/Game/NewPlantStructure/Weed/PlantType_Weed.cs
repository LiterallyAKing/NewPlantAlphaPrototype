using UnityEngine;
using System.Collections;

public class PlantType_Weed : PlantType_Base {

	public Plant_MasterManager mymastermanager;




	float timer = 0;
	float timelimit = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > timelimit) {
			timer = 0;
			int plantneighbors = mymastermanager.plantmanager.HowManyPlantsAroundCell (mymastermanager.locmanager.mycell, this);
			if (plantneighbors < 1 || plantneighbors > 5) {
				Destroy (this.gameObject);
			}
		}
	
	}
}
