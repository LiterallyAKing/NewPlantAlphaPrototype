using UnityEngine;
using System.Collections;

public class WeedLogic : MonoBehaviour {

	[System.Serializable]
	public class PlantTriggers
	{
		public int minLight_grow = 0;
		public int minWater_grow = -1;
		public int minLight_spread = -1;
		public int minWater_spread = 1;
	}
	[SerializeField] public PlantTriggers planttriggers;

	[Space(5)]
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
	
	public void PlantLogicProcess(){
		
		//DEATH
		if(mygridstats.Water == -2){
			//Dead



		}
		int plantneighbors = 0;
		for (int i = 0; i < mycell.neighbors.Length; i++) {
			if (mycell.neighbors [i] != null) {
				if (mycell.neighbors [i].plantincell != null) {
					if (mycell.neighbors [i].plantincell.gameObject.name == this.gameObject.name) {
						plantneighbors++;
					}
				}
			}
		}
		if (plantneighbors >= 7 || plantneighbors <= 0) {
			growState_current--;
			growState_current--;
			if (growState_current <= 0) {
				Destroy (this.gameObject);
			} else {

				float newSize;
				newSize = ((float)growState_current / (float)growState_total);
				transform.localScale = ((maxSize - minSize) * newSize) + minSize;
			}
		}


		//GROW
		if(mygridstats.Light >= planttriggers.minLight_grow && mygridstats.Water >= planttriggers.minWater_grow){
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
			if (mygridstats.Light >= planttriggers.minLight_spread && mygridstats.Water >= planttriggers.minWater_spread) {
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
									if (plantsnearby >= 3 && plantsnearby <= 6) {
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
