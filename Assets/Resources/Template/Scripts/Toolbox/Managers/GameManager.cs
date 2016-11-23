using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	[Range(0f,2f)] public float tick_speed;

	GridManager gridman;
	GameObject slidermenu;


	// Use this for initialization
	void Start () {
		gridman = GameObject.Find ("Grid").GetComponent<GridManager> ();
		slidermenu = GameObject.Find ("SettingsMenu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//reset function
}
