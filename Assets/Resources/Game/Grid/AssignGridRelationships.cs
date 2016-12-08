using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AssignGridRelationships : MonoBehaviour {
	void Start () {
		GridManager gridman = GetComponent<GridManager> ();
		foreach (GridCell gridcell in gridman.cells) {
			GridStats stats = gridcell.GetComponent<GridStats> ();
			stats.mycell = gridcell;
		}
	}

}
