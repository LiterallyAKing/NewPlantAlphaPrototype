using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TreeTest : MonoBehaviour {



	public GameObject[] branches;
	public GameObject[] leafs;



	float timetogrow = 0;
	float timer;
	// Use this for initialization
	void Start () {
		timetogrow = Random.Range (40f, 60f);

		float firstscale = Random.Range (0.1f, 0.3f);
		transform.DOScale (new Vector3 (firstscale, firstscale, 1f), 5f);


		foreach (GameObject leaf in leafs) {
			Vector3 origilrot = leaf.transform.localRotation.eulerAngles;
			origilrot += new Vector3(0,0,Random.Range(-20f,20f));
			Quaternion newrot = Quaternion.Euler (origilrot);
			leaf.transform.localRotation = newrot;

			leaf.transform.localScale = new Vector3 (0, 0, 0);

		}
		foreach (GameObject branch in branches) {
			Vector3 origilrot = branch.transform.localRotation.eulerAngles;
			origilrot += new Vector3(0,0,Random.Range(-15f,15f));
			Quaternion newrot = Quaternion.Euler (origilrot);
			branch.transform.localRotation = newrot;

			branch.transform.localScale = new Vector3 (0, 0, 0);
		}

	}
	
	// Update is called once per frame

	bool startgrow = false;
	int branchnum = 0;

	void Update () {
		timer += Time.deltaTime;
		if (timer > 5f && !startgrow) {
			startgrow = true;
			float finalsize = Random.Range (0.8f, 1.2f);
			transform.DOScale (new Vector3 (finalsize, finalsize, 1f), timetogrow);
		}
		if (timer > (timetogrow / 5f) * ((float)(branchnum + 1))) {
			if (branchnum <= 5) {
				branchnum++;
				float branchsize = Random.Range (0.7f, 0.9f);
				branches [branchnum].transform.DOScale (new Vector3 (branchsize, branchsize, 1f), (timetogrow / 6f) * Random.Range(0.5f,1.5f));
				foreach (Transform leaf in branches[branchnum].transform) {
					float leafsize = Random.Range (0.9f, 1.2f);
					leaf.DOScale (new Vector3 (leafsize, leafsize, 1f), (timetogrow / 8f) * Random.Range(0.5f,1.5f));
				}

			}
		}

			
	}
}
