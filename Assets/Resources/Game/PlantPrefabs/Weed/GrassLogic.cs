using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class GrassLogic : MonoBehaviour {

	public PlantLogistics myplantlog;
	private GridCell mycell;
	private GridStats mygridstats;
	public GameObject bladeprefab;
	public Vector2 NumOfBladesMinMax;
	List<GameObject> blades = new List<GameObject>();
	int curblade = 0;

	// Use this for initialization
	void Start () {
		mycell = myplantlog.mycell;
		mygridstats = myplantlog.mycellStats;
		int numofblades = Random.Range ((int)NumOfBladesMinMax.x, (int)NumOfBladesMinMax.y);
		for (int i = 0; i < numofblades; i++) {
			Vector3 pos = new Vector3 (Random.Range (-0.2f, 0.2f), -0.15f, Random.Range (-0.2f, 0.2f));
			GameObject newblade = Instantiate (bladeprefab, this.transform) as GameObject;
			newblade.transform.localPosition = pos;
			blades.Add (newblade);
			newblade.SetActive (false);
		}


		//transform.localScale = minSize;
	}
	
	public void PlantLogicProcess(){
		
		//DEATH
		if(mygridstats.Water == -2){
			//Dead
		}
		//GROW
		if(mygridstats.Light >= -1 && mygridstats.Water >= -1){
			if (curblade < blades.Count) {
				blades [curblade].SetActive (true);
				Vector3 newpos = blades [curblade].transform.localPosition;
				blades [curblade].transform.DOLocalMove (new Vector3 (newpos.x, 0.15f, newpos.z), Random.Range (15f, 30f), false);
				curblade++;
//				if (curblade >= blades.Count) {
//					foreach (GameObject blade in blades) {
//						blade.GetComponent<WaveInBreeze> ().enabled = true;
//					}
//				}
			}

		}

		//REPRODUCE
		bool canPlant = true;
		//if (growState_current == growState_total) {
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
												//if (mycell.neighbors [i].neighbors [j].plantincell.GetComponent<GrassLogic> ().growState_current == growState_total) {
													plantsnearby++;
												//}
											}
										}
									}
									if (plantsnearby > 1) {
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
		//}






		}






}
