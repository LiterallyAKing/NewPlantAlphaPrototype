using UnityEngine;
using System.Collections;

public class BushLogic : MonoBehaviour {

	public PlantLogistics myplantlog;
	private GridCell mycell;
	private GridStats mygridstats;
	public Vector3 minSize;
	public Vector3 maxSize;

	int growState_current = 1;
	int growState_total = 5;

	// Use this for initialization
	void Start () {
		mycell = myplantlog.mycell;
		mygridstats = myplantlog.mycellStats;
		transform.localScale = minSize;

		player = GameObject.Find ("Player").transform;
	}

	float growtimer = 0;
	float growdelay = 1f;
	float speedmultiplier = 1f;
	Transform player;
	void Update(){
		float dist = Vector3.Distance (transform.position, player.position);
		if (dist > 5f) {
			speedmultiplier = 0.1f;
		} else {
			speedmultiplier = 5f - (4.9f * (dist / 10f));
		}

		growtimer += (Time.deltaTime * speedmultiplier);
		if (growtimer > growdelay) {
			PlantLogicProcess ();
			growtimer = 0f;
		}

	}


	bool KillNeighbor(){
		bool toreturn = false;
		for (int i = 0; i < mycell.neighbors.Length; i++) {
			if (mycell.neighbors [i] != null) {
				if (mycell.neighbors [i].plantincell != null) {
					if (mycell.neighbors [i].plantincell.gameObject.name != this.gameObject.name) {
						Destroy (mycell.neighbors [i].plantincell.gameObject);
						mycell.neighbors [i].plantincell = null;
						toreturn = true;
					}
				}
			}
		}
		return toreturn;
	}
		
	public void PlantLogicProcess(){
		
		//DEATH
		if(mygridstats.Water == -2){
			//Dead
		}
		//GROW
		if(mygridstats.Light >= -1 && mygridstats.Water >= -1){
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
			if (mygridstats.Light >= -1 && mygridstats.Water >= -1) {
				for (int i = 0; i < mycell.neighbors.Length; i++) {
					if (canPlant) {
						if (mycell.neighbors [i] != null) {
							if (!(mycell.neighbors [i].plantincell != null)) {
								int plantsnearby = 0;
								for (int j = 0; j < mycell.neighbors [i].neighbors.Length; j++) {
									if (mycell.neighbors [i].neighbors [j] != null) {
										if (mycell.neighbors [i].neighbors [j].plantincell != null) {
											if (mycell.neighbors [i].neighbors [j].plantincell.gameObject.name == this.gameObject.name) {
												if (mycell.neighbors [i].neighbors [j].plantincell.GetComponent<BushLogic> ().growState_current == growState_total) {
													plantsnearby++;
												}
											}
										}
									}
									if (plantsnearby >= 0 && plantsnearby <= 2) {
										if (KillNeighbor ()) {
											//myplantlog.myplantman.CreatePlant (myplantlog.myPlantIndex, mycell.neighbors [i].coordinates);
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






}
