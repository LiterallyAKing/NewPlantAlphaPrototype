using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Plant_VisualsManager : MonoBehaviour {

	public GameObject[] plantParts;

	public void scalePart(int index, float percent, float duration){
		percent = Mathf.Clamp (percent, 0f, 1f);
		plantParts [index].transform.DOScale (Vector3.one * percent, 1f);
	}

	public void SetSortOrder(int order){
		for (int i = 0; i < plantParts.Length; i++) {
			plantParts [i].GetComponentInChildren<MeshRenderer> ().sortingLayerName = "PlantsPlayer";
			plantParts [i].GetComponentInChildren<MeshRenderer> ().sortingOrder = order;
		}
	}




}
