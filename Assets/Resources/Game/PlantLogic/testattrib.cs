using UnityEngine;
using System.Collections;

public class testattrib : testroot {




	// Use this for initialization
	void Start () {
		if (GetComponent<testattrib> () is testroot) {
			print ("YASS");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
