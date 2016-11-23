using UnityEngine;
using System.Collections;

public class WeedLogic : MonoBehaviour {

	public PlantLogistics myplantlog;
	private GridCell mycell;
	private GridStats mygridstats;
	public Vector3 minSize;
	public Vector3 maxSize;


	// Use this for initialization
	void Start () {
		mycell = myplantlog.mycell;
		mygridstats = myplantlog.mycellStats;
		transform.localScale = minSize;
	}
	
	public void PlantLogic(){
		
	}



}
