﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour {

	public GridManager gridman;
	Vector3 destination;
	public float moveSpeed;
	public GridCell currentCell;

	// Use this for initialization
	void Start () {
		destination = transform.position;
		currentCell = CurrentlyOn (transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		currentCell = CurrentlyOn (transform.position);

		if (Input.GetMouseButtonDown(0)) {
			if(!EventSystem.current.IsPointerOverGameObject()){
				HandleInput();
			}
		}

		transform.position = Vector3.MoveTowards (transform.position, destination, moveSpeed);

	}

	void HandleInput () {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			GoToCell(hit.point);
		}
	}

	public void GoToCell (Vector3 position) {
		position = transform.InverseTransformPoint(position);
		position += transform.position;
		GridCoordinates coordinates = GridCoordinates.FromPosition (position);
		GridCell cell = gridman.GetCell (coordinates);
		if (cell != null) {
			destination = cell.transform.position;
		}
	}


	GridCell CurrentlyOn(Vector3 pos){
		GridCoordinates coordinates = GridCoordinates.FromPosition (pos);
		GridCell cell = gridman.GetCell (coordinates);
		return cell;
	}

}
