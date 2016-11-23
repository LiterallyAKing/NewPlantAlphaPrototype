using UnityEngine;
using System.Collections;

public class GridCell : MonoBehaviour {
	public PlantLogistics plantincell;
	public GridCoordinates coordinates;
	public Color color;
	[SerializeField]
	public GridCell[] neighbors;
	public GridCell[] farneighbors;

	public GridCell GetNeighbor(GridDirection direction){
		return neighbors [(int)direction];
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
