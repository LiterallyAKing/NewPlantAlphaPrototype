using UnityEngine;
using System.Collections;

public class PlantType_Weed : PlantType_Base {

	[HideInInspector] public Plant_MasterManager mymastermanager;
	Plant_LocationManager locmanager;
	Plant_VisualsManager vizman;

	public int growthSteps;
	int currentGrowthstep = 0;

	void Start () {
		locmanager = mymastermanager.locmanager;
		vizman = mymastermanager.vizmanager;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public override void PlantProcess(){

		//GROWTH
		if (locmanager.mycellStats.Light >= -2 && locmanager.mycellStats.Water >= -2) {
			vizman.scalePart (0, (float)currentGrowthstep / (float)growthSteps, 1f);
			currentGrowthstep++;
			currentGrowthstep = Mathf.Clamp (currentGrowthstep, 0, growthSteps);
		}

	}
}
