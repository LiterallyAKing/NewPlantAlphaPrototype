using UnityEngine;
using System.Collections;

public class SortingLayerScript : MonoBehaviour {

	public GameObject[] FarthestBack;
	public GameObject[] Background;
	public GameObject[] BadgerSkin;
	public GameObject[] PlantsPlayer;


	public void AssignSortingLayers(){
		if (FarthestBack.Length > 0) {
			for (int i = 0; i < FarthestBack.Length; i++) {
				if (FarthestBack [i].GetComponent<MeshRenderer> () != null) {
					FarthestBack [i].GetComponent<MeshRenderer> ().sortingLayerName = "FarthestBack";
				} else if (FarthestBack [i].GetComponent<SpriteRenderer> () != null) {
					FarthestBack [i].GetComponent<SpriteRenderer> ().sortingLayerName = "FarthestBack";
				}
			}
		}

		if (Background.Length > 0) {
			for (int i = 0; i < Background.Length; i++) {
				if (Background [i].GetComponent<MeshRenderer> () != null) {
					Background [i].GetComponent<MeshRenderer> ().sortingLayerName = "Background";
				} else if (Background [i].GetComponent<SpriteRenderer> () != null) {
					Background [i].GetComponent<SpriteRenderer> ().sortingLayerName = "Background";
				}
			}
		}

		if (BadgerSkin.Length > 0) {
			for (int i = 0; i < BadgerSkin.Length; i++) {
				if (BadgerSkin [i].GetComponent<MeshRenderer> () != null) {
					BadgerSkin [i].GetComponent<MeshRenderer> ().sortingLayerName = "BadgerSkin";
				} else if (BadgerSkin [i].GetComponent<SpriteRenderer> () != null) {
					BadgerSkin [i].GetComponent<SpriteRenderer> ().sortingLayerName = "BadgerSkin";
				}
			}
		}

		if (PlantsPlayer.Length > 0) {
			for (int i = 0; i < PlantsPlayer.Length; i++) {
				if (PlantsPlayer [i].GetComponent<MeshRenderer> () != null) {
					PlantsPlayer [i].GetComponent<MeshRenderer> ().sortingLayerName = "PlantsPlayer";
				} else if (PlantsPlayer [i].GetComponent<SpriteRenderer> () != null) {
					PlantsPlayer [i].GetComponent<SpriteRenderer> ().sortingLayerName = "PlantsPlayer";
				}
			}
		}
	}



	public void SortPlants(){
		
	}



}

