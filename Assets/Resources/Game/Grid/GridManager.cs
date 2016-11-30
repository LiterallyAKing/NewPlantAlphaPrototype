using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class GridManager : MonoBehaviour {
	public int width;//x
	public int height;//z
	public GridCell cellPrefab;
	public GridCell[] cells;
	public Text cellLabelPrefab;
	public PlantMakerManager plantmaker;
	Canvas gridCanvas;

	GridMesh gridMesh;

	void Awake(){
		gridCanvas = GetComponentInChildren<Canvas> ();
		gridMesh = GetComponentInChildren<GridMesh>();
		cells = new GridCell[height * width];

		if (this.transform.childCount == 0) {
			for (int z = 0, i = 0; z < height; z++) {
				for (int x = 0; x < width; x++) {
					CreateCell (x, z, i++);
				}
			}
		}
	}

	void Start(){
	}

	void CreateCell(int x, int z, int i){
		//Setting physical location
		Vector3 position;
		position.x = x * GridMetrics.innerRadius * 1f;
		position.y = 0f;
		position.z = z * GridMetrics.innerRadius *1f;

		//Creating the cell
		GridCell cell = cells [i] = Instantiate<GridCell> (cellPrefab);
		cell.transform.SetParent (transform, false);
		cell.transform.localPosition = position;
		cell.coordinates = GridCoordinates.FromOffsetCoordinates (x, z);
		cell.name = "GridCell_" + cell.coordinates.ToStringForName ();
		//cell.color

		//Setting neighbors;
		if (x > 0) {
			cell.SetNeighbor(GridDirection.W, cells[i-1]);
		}
		if (z > 0) {
			cell.SetNeighbor (GridDirection.S, cells [i - width]);
		}
		if ((x > 0) && (z > 0)) {
			cell.SetNeighbor (GridDirection.SW, cells [i - (width + 1)]);
		}
		if ((x < (width - 1)) && (z > 0)) {
			cell.SetNeighbor (GridDirection.SE, cells [i - (width - 1)]);
		}
		//Setting farneighbors;
			//N 0
				if (cell.neighbors[0] != null) {
					if (cell.neighbors [0].neighbors [0] != null) {
							cell.SetFarNeighbor(GridFarDirection.N, cell.neighbors [0].neighbors [0]);
						}
					}
			//NNE 1
				if (cell.neighbors[1] != null) {
					if (cell.neighbors [1].neighbors [0] != null) {
						cell.SetFarNeighbor(GridFarDirection.NNE, cell.neighbors [1].neighbors [0]);
					}
				}
			//NE 2
				if (cell.neighbors[1] != null) {
					if (cell.neighbors [1].neighbors [1] != null) {
						cell.SetFarNeighbor(GridFarDirection.NE, cell.neighbors [1].neighbors [1]);
					}
				}
			//NEE 3
				if (cell.neighbors[1] != null) {
					if (cell.neighbors [1].neighbors [2] != null) {
						cell.SetFarNeighbor(GridFarDirection.NEE, cell.neighbors [1].neighbors [2]);
					}
				}
			//E 4
				if (cell.neighbors[2] != null) {
					if (cell.neighbors [2].neighbors [2] != null) {
						cell.SetFarNeighbor(GridFarDirection.E, cell.neighbors [2].neighbors [2]);
					}
				}
			//SEE 5
				if (cell.neighbors[3] != null) {
					if (cell.neighbors [3].neighbors [2] != null) {
						cell.SetFarNeighbor(GridFarDirection.SEE, cell.neighbors [3].neighbors [2]);
					}
				}
			//SE 6
				if (cell.neighbors[3] != null) {
					if (cell.neighbors [3].neighbors [3] != null) {
						cell.SetFarNeighbor(GridFarDirection.SE, cell.neighbors [3].neighbors [3]);
					}
				}
			//SSE 7
				if (cell.neighbors[3] != null) {
					if (cell.neighbors [3].neighbors [4] != null) {
						cell.SetFarNeighbor(GridFarDirection.SSE, cell.neighbors [3].neighbors [4]);
					}
				}
			//S 8
				if (cell.neighbors[4] != null) {
					if (cell.neighbors [4].neighbors [4] != null) {
						cell.SetFarNeighbor(GridFarDirection.S, cell.neighbors [4].neighbors [4]);
					}
				}
			//SSW 9
				if (cell.neighbors[5] != null) {
					if (cell.neighbors [5].neighbors [4] != null) {
						cell.SetFarNeighbor(GridFarDirection.SSW, cell.neighbors [5].neighbors [4]);
					}
				}
			//SW 10
				if (cell.neighbors[5] != null) {
					if (cell.neighbors [5].neighbors [5] != null) {
						cell.SetFarNeighbor(GridFarDirection.SW, cell.neighbors [5].neighbors [5]);
					}
				}
			//SWW 11
				if (cell.neighbors[6] != null) {
					if (cell.neighbors [6].neighbors [5] != null) {
						cell.SetFarNeighbor(GridFarDirection.SWW, cell.neighbors [6].neighbors [5]);
					}
				}
			//W 12
				if (cell.neighbors[6] != null) {
					if (cell.neighbors [6].neighbors [6] != null) {
						cell.SetFarNeighbor(GridFarDirection.W, cell.neighbors [6].neighbors [6]);
					}
				}
			//NWW 13
				if (cell.neighbors[7] != null) {
					if (cell.neighbors [7].neighbors [6] != null) {
						cell.SetFarNeighbor(GridFarDirection.NWW, cell.neighbors [7].neighbors [6]);
					}
				}
			//NW 14
				if (cell.neighbors[7] != null) {
					if (cell.neighbors [7].neighbors [7] != null) {
						cell.SetFarNeighbor(GridFarDirection.NW, cell.neighbors [7].neighbors [7]);
					}
				}
			//NWW 15
				if (cell.neighbors[7] != null) {
					if (cell.neighbors [7].neighbors [0] != null) {
						cell.SetFarNeighbor(GridFarDirection.NWW, cell.neighbors [7].neighbors [0]);
					}
				}

		//ADDING LABEL
//		Text label = Instantiate<Text> (cellLabelPrefab);
//		label.rectTransform.SetParent (gridCanvas.transform, false);
//		label.rectTransform.anchoredPosition = new Vector2 (position.x, position.z);
//		label.text = cell.coordinates.ToStringOnSeparateLines ();
	}

	void Update () {
//		if (Input.GetMouseButton(0)) {
//			HandleInput();
//		}
	}

	public GridCell GetCell(int x, int z){
		int index = x + (z * width);
		return cells [index];
	}
	public GridCell GetCell(GridCoordinates coords){
		int index = coords.X + (coords.Z * width);
		return cells [index];
	}


	void HandleInput () {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			TouchCell(hit.point);
		}
	}

	public void TouchCell (Vector3 position) {
		position = transform.InverseTransformPoint(position);
		GridCoordinates coordinates = GridCoordinates.FromPosition (position);
		int index = coordinates.X + (coordinates.Z * width);
		GridCell cell = cells [index];
		plantmaker.MakePlant (coordinates);
	}

}
