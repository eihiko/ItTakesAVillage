using UnityEngine;
using System.Collections;

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
		//Move (0, 0);
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

			if (Input.GetKeyDown (KeyCode.Space)) {
			    if (isFree ())
				{
					Debug.Log("Placing object");
					markTaken();
					willPlace = null;
				}
			}
			/*
			else if (Input.GetKeyDown (KeyCode.A)) {
				if (currentx>0)
				{
					Move (-1,0);
				}
			}
			else if (Input.GetKeyDown (KeyCode.D)) {
				if (currentx<((int)gridSize.x)-willPlace.size.x)
				{
					Move (1,0);
				}
			}
			else if (Input.GetKeyDown (KeyCode.S)) {
				if (currenty>0)
				{
					Move (0,-1);
				}
			}
			else if (Input.GetKeyDown (KeyCode.W)) {
				if (currenty<((int)gridSize.y)-willPlace.size.y)
				{
					Move (0,1);
				}
			}
			*/
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

	/*
	//Moves willPlace by amount given
	void Move(int xAmount, int yAmount) {
		currentx += xAmount;
		currenty += yAmount;
		Vector3 newPos = willPlace.transform.position;
		newPos.x = (willPlace.size.x / 2) + (currentx*squareSize.x);
		newPos.z = (willPlace.size.y / 2) + (currenty*squareSize.y);
		willPlace.transform.localPosition = newPos;
		willPlace.setConflict(!isFree ());
	}
	*/

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
