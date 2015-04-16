using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingPlacer : MonoBehaviour {

	public Vector2 gridSize;
	public Vector2 squareSize;
	public BuildingManager buildingManager;
	public Transform highlightQuad;
	public Material greenMat;
	public Material redMat;
	public Text deleteModeText;

	private bool[,] grid;
	private Transform[,] highlightGrid;
	private Building willPlace = null;
	private int currentx;
	private int currenty;
	private Plane placementPlane;
	private bool highlighted = true;
	private bool deleteMode = false;

	// Use this for initialization
	void Start () {
		grid = new bool[(int)gridSize.x,(int)gridSize.y];

		const float highlightCellSizeX = 0.5f;
		const float highlightCellSizeY = 0.5f;
		highlightGrid = new Transform[(int)gridSize.x, (int)gridSize.y];
		for (int i=0; i<gridSize.x; i++) {
			for (int j=0; j<gridSize.y; j++) {
				Vector3 position = new Vector3(0,1,0);
				position.x = i*squareSize.x + highlightCellSizeX;
				position.z = j*squareSize.y + highlightCellSizeY;
				highlightGrid[i,j] = (Transform)Instantiate(highlightQuad, position, highlightQuad.rotation);
				highlightGrid[i,j].localScale = new Vector3(squareSize.x, squareSize.y, 1);
				highlightGrid[i,j].renderer.material = greenMat;
			}
		}
		stopHighlight ();
		deleteModeText.enabled = false;
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
			Destroy(willPlace.gameObject);	
		}
		else if (!willPlace.HaveResources ()) {
			Destroy(willPlace.gameObject);
		}
	}

	//Place a building on specific location
	public void Place(Building building, int x, int y, int rotation) {
		Vector3 newPosition = building.transform.localPosition;
		newPosition.x = x*squareSize.x + building.size.x/2;
		newPosition.z = y*squareSize.y + building.size.y/2;
		building.transform.localPosition = newPosition;
		building.setConflict(!isFree ());
		building.setCoordinates (x, y);
		building.rotation = rotation;
		buildingManager.addBuilding (building);

		//rotate
		print ("The rotation is " + rotation.ToString());
		for (int i=0; i<rotation; i++) {
			building.transform.RotateAround (building.transform.position, building.transform.up, 90f);
		}

		//mark ground taken
		for (int i = 0; i < building.size.x/squareSize.x; i++) {
			for (int j = 0; j < building.size.y/squareSize.y; j++) {
				grid[x+i,y+j] = true;
				highlightGrid[x+i, y+j].renderer.material = redMat;
			}	
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawRay (ray.origin, ray.direction * 100, Color.yellow);
		if (willPlace != null) {
			startHighlight();

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			float distance;
			if (placementPlane.Raycast (ray, out distance)) {
				Vector3 hitPoint = ray.GetPoint(distance);
				Move (hitPoint);
			}

			if (Input.GetKeyDown (KeyCode.Mouse1)) {
				willPlace.rotate();
			}

			if (Input.GetKeyDown (KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject()) {
			    if (isFree ())
				{
					willPlace.SpendResources();
					markTaken();
					buildingManager.addBuilding(willPlace);
					willPlace = null;
					stopHighlight();
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			if (deleteMode) {
				deleteMode = false;
				deleteModeText.enabled = false;
				stopHighlight();
			}
			else {
				deleteMode = true;
				deleteModeText.enabled = true;
				startHighlight();
			}
		}
		if (deleteMode && Input.GetKeyDown (KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject()) {
			willPlace = null;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			int layerMask = 1 << 8;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
				print ("Should destroy a building");
				Building buildingScript = hit.transform.parent.GetComponent<Building>();
				print ("The X coordinate is " + buildingScript.getX());
				deleteBuilding(hit.transform.parent.gameObject, buildingScript);
			}
			else 
				print ("Did not hit anything.");
		}
	}

	public void deleteBuilding(GameObject building, Building buildingScript) {
		//Delete the building from the list 
		buildingManager.removeBuilding (buildingScript);
		//Mark the ground as available
		int buildingX = buildingScript.getX ();
		int buildingY = buildingScript.getY ();
		for (int x = 0; x < buildingScript.size.x/squareSize.x; x++) {
			for (int y = 0; y < buildingScript.size.y/squareSize.y; y++) {
				grid[x+buildingX,y+buildingY] = true;
				highlightGrid[x+buildingX, y+buildingY].renderer.material = greenMat;
			}	
		}
		//Delete the gameobject
		Destroy (building);
	}

	public void markTaken()
	{
		for (int x = 0; x < willPlace.size.x/squareSize.x; x++) {
			for (int y = 0; y < willPlace.size.y/squareSize.y; y++) {
				grid[x+currentx,y+currenty] = true;
				highlightGrid[x+currentx, y+currenty].renderer.material = redMat;
			}	
		}
	}

	//Highlights the cells where a building can be placed
	void startHighlight() {
		if (!highlighted) {
			for (int i=0; i<gridSize.x; i++) {
				for (int j=0; j<gridSize.y; j++) {
					highlightGrid[i,j].renderer.enabled = true;
				}
			}
			highlighted = true;
		}
	}

	void stopHighlight() {
		if (highlighted) {
			for (int i=0; i<gridSize.x; i++) {
				for (int j=0; j<gridSize.y; j++) {
					highlightGrid[i,j].renderer.enabled = false;
				}
			}
			highlighted = false;
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
