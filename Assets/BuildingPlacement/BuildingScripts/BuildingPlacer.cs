<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BuildingPlacer : MonoBehaviour {

	public Vector2 gridSize;
	public Vector2 squareSize;

	private bool[,] grid;
	private Building willPlace = null;
	private int currentx;
	private int currenty;
	private Plane placementPlane;

	// Use this for initialization
	void Start () {
		grid = new bool[(int)gridSize.x,(int)gridSize.y];
		// Note: If the starting position's height may change, the plane initialization must be changed
		placementPlane = new Plane (Vector3.up, new Vector3(0,0,0));
	}

	//Takes a Building gameObject and places it
	public void Place(Building toPlace)
	{
		Debug.Log("Starting to place building");
		if (willPlace != null) {
			Destroy(willPlace.gameObject);	
		}
		willPlace = toPlace;
		currentx = 0;
		currenty = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawRay (ray.origin, ray.direction * 100, Color.yellow);
		if (willPlace != null) {

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float distance;
			if (placementPlane.Raycast (ray, out distance)) {
				Vector3 hitPoint = ray.GetPoint(distance);
				Move (hitPoint);
			}

			if (Input.GetKeyDown (KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject()) {
			    if (isFree ())
				{
					Debug.Log("Placing object");
					markTaken();
					willPlace = null;
				}
			}
		}
	}

	public void markTaken()
	{
		for (int x = 0; x < willPlace.size.x; x++) {
			for (int y = 0; y < willPlace.size.y; y++) {
				grid[x+currentx,y+currenty] = true;
			}	
		}
	}

	//Move to the position
	//The mouse position (the input) is the center of the bottom left building cell
	//The building position is determined by the position of the center
	//currentx and currenty contain the coordinates of the bottom left building cell
	void Move(Vector3 position) {
		//Tie it to the grid (move to the closest middle of the gtid cell)
		position.x = Mathf.FloorToInt (position.x - 0.5f) + 0.5f;
		position.z = Mathf.FloorToInt (position.z - 0.5f) + 0.5f;
		//Force it inside the grid
		position.x = Mathf.Min (position.x, gridSize.x + squareSize.x/2 - willPlace.size.x);
		position.z = Mathf.Min (position.z, gridSize.y + squareSize.y/2 - willPlace.size.y);
		position.x = Mathf.Max (position.x, squareSize.x/2);
		position.z = Mathf.Max (position.z, squareSize.y/2);
		//Update current x and y
		currentx = Mathf.FloorToInt(position.x);
		currenty = Mathf.FloorToInt(position.z);
		//Update the object's position
		Vector3 newPosition = willPlace.transform.localPosition;
		newPosition.x = position.x + willPlace.size.x/2 - squareSize.x / 2;
		newPosition.z = position.z + willPlace.size.y/2 - squareSize.y / 2;
		willPlace.transform.localPosition = newPosition;
		willPlace.setConflict(!isFree ());
	}

	bool isFree() {
		//This checks for disqualifiers
		if (willPlace == null || willPlace.size.x + currentx > gridSize.x || willPlace.size.y + currenty > gridSize.y) {
			return false;	
		}

		//This runs through every square for conflicts
		for (int x = 0; x < willPlace.size.x; x++) {
			for (int y = 0; y < willPlace.size.y; y++) {
				if (grid[x+currentx,y+currenty]) {
					return false;
				}
			}	
		}
		return true;	
	}
}
=======
﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class BuildingPlacer : MonoBehaviour {

	public Vector2 gridSize;
	public Vector2 squareSize;
	public GameControl controller;
	public BuildingManager buildingManager;

	private bool[,] grid;
	private Building willPlace = null;
	private int currentx;
	private int currenty;
	private Plane placementPlane;

	// Use this for initialization
	void Start () {
		grid = new bool[(int)gridSize.x,(int)gridSize.y];
		// Note: If the starting position's height may change, the plane initialization must be changed
		placementPlane = new Plane (Vector3.up, new Vector3(0,0,0));

		/*
		//test the building placement
		StoredBuilding b1 = new StoredBuilding (0, 0, 0);
		StoredBuilding b2 = new StoredBuilding (1, 4, 2);
		StoredBuilding b3 = new StoredBuilding (2, 6, 7);
		List<StoredBuilding> list = new List<StoredBuilding> ();
		list.Add (b1);
		list.Add (b2);
		list.Add (b3);
		buildingManager.loadBuildings (list);
		*/
	}

	//Takes a Building gameObject and places it
	public void Place(Building toPlace)
	{
		if (willPlace != null) {
			Destroy(willPlace.gameObject);	
		}
		willPlace = toPlace;
		currentx = 0;
		currenty = 0;
		if (willPlace.locked) {
			Debug.Log("Locked");
			Destroy(willPlace.gameObject);	
		}
		else if (!willPlace.HaveResources (controller)) {
			Debug.Log("No resources");
			Destroy(willPlace.gameObject);
		}
	}

	//Place a building on specific location
	public void Place(Building building, int x, int y) {
		Vector3 newPosition = building.transform.localPosition;
		newPosition.x = x*squareSize.x + building.size.x/2;
		newPosition.z = y*squareSize.y + building.size.y/2;
		building.transform.localPosition = newPosition;
		building.setConflict(!isFree ());
		building.setCoordinates (x, y);
		buildingManager.addBuilding (building);

		for (int i = 0; i < building.size.x/squareSize.x; i++) {
			for (int j = 0; j < building.size.y/squareSize.y; j++) {
				grid[x+i,y+j] = true;
			}	
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawRay (ray.origin, ray.direction * 100, Color.yellow);
		if (willPlace != null) {

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float distance;
			if (placementPlane.Raycast (ray, out distance)) {
				Vector3 hitPoint = ray.GetPoint(distance);
				Move (hitPoint);
			}

			if (Input.GetKeyDown (KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject()) {
			    if (isFree ())
				{
					willPlace.SpendResources(controller);
					markTaken();
					buildingManager.addBuilding(willPlace);
					willPlace = null;
				}
			}
		}
	}

	public void markTaken()
	{
		for (int x = 0; x < willPlace.size.x/squareSize.x; x++) {
			for (int y = 0; y < willPlace.size.y/squareSize.y; y++) {
				grid[x+currentx,y+currenty] = true;
			}	
		}
	}

	//Move to the position
	//The mouse position (the input) is the center of the bottom left building cell
	//The building position is determined by the position of the center
	//currentx and currenty contain the coordinates of the bottom left building cell
	void Move(Vector3 position) {
		//Tie it to the grid (move to the closest middle of the grid cell)
		position.x = Mathf.FloorToInt ((position.x - willPlace.size.x/2f+0.25f)/squareSize.x);
		position.z = Mathf.FloorToInt ((position.z - willPlace.size.y/2f+0.25f)/squareSize.y);
		//Force it inside the grid
		position.x = Mathf.Min (position.x, gridSize.x - willPlace.size.x/squareSize.x);
		position.z = Mathf.Min (position.z, gridSize.y - willPlace.size.y/squareSize.y);
		position.x = Mathf.Max (position.x, 0);
		position.z = Mathf.Max (position.z, 0);
		//Update current x and y
		currentx = Mathf.FloorToInt(position.x);
		currenty = Mathf.FloorToInt(position.z);
		//Update the object's position
		Vector3 newPosition = willPlace.transform.localPosition;
		newPosition.x = position.x*squareSize.x + willPlace.size.x/2;
		newPosition.z = position.z*squareSize.y + willPlace.size.y/2;
		willPlace.transform.localPosition = newPosition;
		willPlace.setConflict(!isFree ());
		willPlace.setCoordinates (currentx, currenty);
	}

	bool isFree() {
		//This checks for disqualifiers
		if (willPlace == null || willPlace.size.x/squareSize.x + currentx > gridSize.x 
		    || willPlace.size.y/squareSize.y + currenty > gridSize.y) {
			return false;	
		}

		//This runs through every square for conflicts
		for (int x = 0; x < willPlace.size.x/squareSize.x; x++) {
			for (int y = 0; y < willPlace.size.y/squareSize.x; y++) {
				if (grid[x+currentx,y+currenty]) {
					return false;
				}
			}	
		}
		return true;	
	}
}
>>>>>>> master
