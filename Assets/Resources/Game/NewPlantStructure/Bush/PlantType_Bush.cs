using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlantType_Bush : PlantType_Base {


	bool justBorn = true;

	public int growthSteps;
	int currentGrowthstep = 0;

	
	// Update is called once per frame
	void Update () {

	}

	public override void PlantProcess(){
		

		//GROWTH
		if (locmanager.mycellStats.Water >= 1) {
			justBorn = false;
			currentGrowthstep++;
			currentGrowthstep = Mathf.Clamp (currentGrowthstep, 0, growthSteps);
			vizman.scalePart (0, (float)currentGrowthstep / (float)growthSteps, 1f);
		}

		//REPRODUCE
		if(locmanager.mycellStats.Water >= 1){
			if (currentGrowthstep >= growthSteps) {
				List<GridCell> neighbors = locmanager.mycell.GetNeighbors ();
				neighbors.Shuffle ();
				bool havePlanted = false;
				for (int i = 0; i < neighbors.Count; i++) {
					if (!havePlanted) {
						if (neighbors [i].occupied) {
							if (neighbors [i].plantincell.GetType () != this.GetType ()) {
								if (mymastermanager.plantmanager.HowManyPlantsAroundCell (neighbors [i], this) >= 2) {
									neighbors [i].plantincell.mymanager.Die ();
									mymastermanager.plantmanager.CreatePlant (this.GetType (), neighbors [i].coordinates);
									havePlanted = true;
								}
							}
						}
					}
				}
			}
		}

		//SHRINK WHEN OVERPOPULATED
		if (currentGrowthstep >= 1) {
			if (mymastermanager.plantmanager.HowManyPlantsAroundCell (locmanager.mycell, this) >= 3) {
					currentGrowthstep--;
					currentGrowthstep = Mathf.Clamp (currentGrowthstep, 0, growthSteps);
					vizman.scalePart (0, (float)currentGrowthstep / (float)growthSteps, 1f);
				}

		}

		if (!justBorn && currentGrowthstep == 0) {
			mymastermanager.Die ();
		}


	}
}
