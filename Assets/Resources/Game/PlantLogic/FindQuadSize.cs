using UnityEngine;
using System.Collections;

public class FindQuadSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
			Texture tex = GetComponent<MeshRenderer> ().material.mainTexture;
			Vector2 scale = new Vector2(Screen.width/2f, Screen.height / 2f);
			transform.localScale = new Vector3 (tex.width/scale.x, tex.height/scale.y, 1);
	
	}

}
