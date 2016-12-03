using UnityEngine;
using System.Collections;

public class PlantProcessManager : MonoBehaviour {

	public PlantManager plantman;
	public WeatherManager weatherman;
	Timer autoProcess;

	void Start(){
		autoProcess = new Timer (1f, true);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Space) || autoProcess.IsFinished()) {
			weatherman.ChangeWeather ();
			//DoPlantProcess ();
		}
	}

	void DoPlantProcess(){
		BroadcastMessage ("PlantLogicProcess");
	}


}
