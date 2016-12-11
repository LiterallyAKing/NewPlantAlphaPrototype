using UnityEngine;
using System.Collections;

public class CameraLurch : MonoBehaviour {

	public ParallaxManager parallaxman;
	Vector3 originalpos;

	void Start(){
		originalpos = transform.position;
	}

	Vector3 velocity = Vector3.zero;
	void Update(){

		float xdisplace = -0.2f * parallaxman.rawdisplacement;


		Vector3 target =  new Vector3 (transform.position.x + xdisplace, originalpos.y - (parallaxman.rawdisplacement * 0.8f), transform.position.z);
		//transform.position  =  new Vector3 (transform.position.x, originalpos.y - parallaxman.rawdisplacement, transform.position.z);
		transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, parallaxman.walkTime/10f);

	}

}
