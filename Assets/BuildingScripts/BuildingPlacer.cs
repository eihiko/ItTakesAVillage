using UnityEngine;
using System.Collections;

public class BuildingPlacer : MonoBehaviour {

	public Vector2 gridSize;
	public Vector2 squareSize;

	private bool[,] grid;
	private Building willPlace = null;
	private int currentx;
	private int currenty;
	// Use this for initialization
	void Start () {
		grid = new bool[(int)gridSize.x,(int)gridSize.y];
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
		Move (0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (willPlace != null) {
			if (Input.GetKeyDown (KeyCode.Space)) {
			    if (isFree ())
				{
					Debug.Log("Placing object");
					markTaken();
					willPlace = null;
				}
			}
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
