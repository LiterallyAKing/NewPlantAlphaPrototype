using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxManager : MonoBehaviour {

	public GameObject player;


	public GameObject[] background_objs;
	Material[] background_mats;
	Vector3[] originalPositions;
	public float[] scrollSpeeds;
	float[] movementPercent;

	Vector2[] savedTextureOffset;

	Vector3 originalPos;

	public AnimationCurve walkcurve;
	public float walkMagnitude = 2f;
	public float walkTime = 5f;
	private float truewalkTime;
	float timer = 0;
	private float scrollSpeedAdjust = 5000f;

	[HideInInspector] public float rawdisplacement = 0;

	// Use this for initialization
	void Start () {
		originalPos = transform.position;
		truewalkTime = walkTime;

		savedTextureOffset = new Vector2[background_objs.Length];
		originalPositions = new Vector3[background_objs.Length];
		background_mats = new Material[background_objs.Length];
		movementPercent = new float[background_objs.Length];

		for (int i = 0; i < background_objs.Length; i++) {
			originalPositions[i] = background_objs [i].transform.localPosition;
			background_mats[i] = background_objs [i].GetComponent<MeshRenderer> ().material;
			savedTextureOffset[i] = background_mats [i].GetTextureOffset ("_MainTex");



		}

		float maxSpeed = MaxAbsVal (scrollSpeeds);
		for (int i = 0; i < scrollSpeeds.Length; i++) {
			movementPercent [i] = Mathf.Abs(scrollSpeeds [i]) / maxSpeed;
		}

	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

	

		if (timer > walkTime) {
			timer -= walkTime;
			walkTime *= Random.Range (0.9f, 1.2f);
		}
		float percent = timer / walkTime;
		float displacement = walkcurve.Evaluate (percent) * walkMagnitude;
		rawdisplacement = displacement;

		for (int i = 0; i < background_objs.Length; i++) {
			//Position
			float localdisplace = displacement * movementPercent [i];
			background_objs [i].transform.localPosition = originalPositions [i] + new Vector3 (0, -localdisplace, 0);

			//Scroll
			float multiplier = scrollSpeeds [i];
			float x = Mathf.Repeat (background_mats [i].GetTextureOffset ("_MainTex").x + (walkcurve.Evaluate (percent) * multiplier / scrollSpeedAdjust), 1f);


			//float x = Mathf.Repeat ((Time.time) * -1f * multiplier, 1);
			Vector2 offset = new Vector2 (x, savedTextureOffset [i].y);
			background_mats [i].SetTextureOffset ("_MainTex", offset);
			

		}


	}


	float MaxAbsVal(float[] floatArray){
		float max = Mathf.Abs (floatArray [0]);
		for (int i = 1; i < floatArray.Length; i++) {
			if (Mathf.Abs (floatArray [i]) > max) {
				max = Mathf.Abs (floatArray [i]);
			}
		}
		return max;
	}


}
