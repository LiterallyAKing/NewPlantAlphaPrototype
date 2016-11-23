using UnityEngine;
using System.Collections;

public class PlantUniqueness : MonoBehaviour {
	public float pos_perturbAmt;
	[Range(0,1)] public float scale_perturbPercent;
	public float rotat_perturbAmt;

	void Start () {
//		Texture tex = GetComponent<MeshRenderer> ().material.mainTexture;
//		Vector2 scale = new Vector2(Screen.width/2f, Screen.height / 2f);
//		transform.localScale = new Vector3 (tex.width/scale.x, tex.height/scale.y, 1);
//


		Vector3 newscale = transform.localScale;
		newscale.x *= Random.Range (1f-(2f*scale_perturbPercent), 1f+(2f*scale_perturbPercent));
		newscale.y *= Random.Range (1f-scale_perturbPercent, 1f+scale_perturbPercent);
		transform.localScale = newscale;

		Vector3 newpos = transform.localPosition;
		newpos.x += Random.Range (-pos_perturbAmt, pos_perturbAmt);
		newpos.z += Random.Range (-pos_perturbAmt, pos_perturbAmt);
		//newpos.y = ((transform.localScale.y * 0.5f) - 0.55f);
		transform.localPosition = newpos;

		Vector3 newrot = transform.localRotation.eulerAngles;
		newrot.z += Random.Range (-rotat_perturbAmt, rotat_perturbAmt);
		transform.eulerAngles = newrot;


		CapSize ();

	}

	void CapSize(){
		if (transform.localScale.x > 1.1f) {
			float resize = 1.1f / transform.localScale.x;
			transform.localScale = new Vector3 (transform.localScale.x * resize, transform.localScale.y * resize, 1f);
		}
	}
}
