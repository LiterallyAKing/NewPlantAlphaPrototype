using UnityEngine;
using System.Collections;

public class WeedLogic : MonoBehaviour {

	public PlantLogistics myplantlog;
	private GridCell mycell;
	private GridStats mygridstats;
	public Vector3 minSize;
	public Vector3 maxSize;

	int growState_current = 1;
	int growState_total = 10;

	// Use this for initialization
	void Start () {
		mycell = myplantlog.mycell;
		mygridstats = myplantlog.mycellStats;
		transform.localScale = minSize;
	}
	
	public void PlantLogicProcess(){
		
		//DEATH
		if(mygridstats.Water == -2){
			//Dead
		}
		//GROW
		if(mygridstats.Light >= 0 && mygridstats.Water >= -1){
			if (growState_current < growState_total) {
				growState_current++;
				float newSize;
				newSize = ((float)growState_current / (float)growState_total);
				transform.localScale = ((maxSize - minSize) * newSize) + minSize;
			}
		}

		//REPRODUCE
		bool canPlant = true;
		if (growState_current == growState_total) {
			if (mygridstats.Light >= -1 && mygridstats.Water >= 1) {
				for (int i = 0; i < mycell.neighbors.Length; i++) {
					if (canPlant) {
						if (mycell.neighbors [i] != null) {
							if (!(mycell.neighbors [i].plantincell != null)) {
								int plantsnearby = 0;
								for (int j = 0; j < mycell.neighbors [i].neighbors.Length; j++) {
									if (mycell.neighbors [i].neighbors [j] != null) {
										if (mycell.neighbors [i].neighbors [j].plantincell != null) {
											if (mycell.neighbors [i].neighbors [j].plantincell.gameObject.name == this.gameObject.name) {
												if (mycell.neighbors [i].neighbors [j].plantincell.GetComponent<WeedLogic> ().growState_current == growState_total) {
													plantsnearby++;
												}
											}
										}
									}
									if (plantsnearby > 2) {
										myplantlog.myplantman.CreatePlant (myplantlog.myPlantIndex, mycell.neighbors [i].coordinates);
										canPlant = false;
										return;
									}
								}
							}
						}
					}
				}
			}
		}






		}






}
