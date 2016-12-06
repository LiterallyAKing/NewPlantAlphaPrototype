using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GridCell : MonoBehaviour {
	public bool occupied {
		get { return plantincell != null; }
	}
	public Plant_LocationManager plantincell;
	public GridCoordinates coordinates;
	public Color color;
	[SerializeField]
	public GridCell[] neighbors;
	public GridCell[] farneighbors;

	public GridCell GetNeighbor(GridDirection direction){
		return neighbors [(int)direction];
	}

	public List<GridCell> GetNeighbors(){
		List<GridCell> toreturn = new List<GridCell> ();
		for (int i = 0; i < neighbors.Length; i++) {
			if (neighbors [i] != null) {
				toreturn.Add (neighbors [i]);
			}
		}
		return toreturn;
	}

	public void SetNeighbor (GridDirection direction, GridCell cell){
		neighbors [(int)direction] = cell;
		cell.neighbors [(int)direction.Opposite ()] = this;
	}
	public void SetFarNeighbor(GridFarDirection direction, GridCell cell){
		farneighbors [(int)direction] = cell;
		cell.farneighbors [(int)direction.Opposite ()] = this;
	}

}
