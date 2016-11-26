using UnityEngine;
using System.Collections;

public class WaveInBreeze : MonoBehaviour {
	
	public float crumpleSpeed = 1f;

	private Vector3[] baseVertices;
	private Mesh mymesh;

	void Start(){
		mymesh = GetComponent<MeshFilter> ().mesh;
		crumpleSpeed *= Random.Range (0.7f, 1.3f);
	}

	// Update is called once per frame
	void Update () {
		if (baseVertices == null)
			baseVertices = mymesh.vertices;

		Vector3[] vertices = new Vector3[baseVertices.Length];

		for (int i = 0; i < vertices.Length; i++) {

			Vector3 vertex = baseVertices [i];
			//vertex.x += noise.Noise (timex + vertex.x, timex + vertex.y, timex + vertex.z) * crumpleScale;
			if (baseVertices [i].y > 0) {
				vertex.x += Mathf.Sin (Mathf.Sin (Time.time) * crumpleSpeed * (Time.time/100f));
			}
			vertices [i] = vertex;
		}

		mymesh.vertices = vertices;
		//mesh.RecalculateNormals ();
		mymesh.RecalculateBounds ();
	}
}
