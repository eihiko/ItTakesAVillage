using UnityEngine;
using System.Collections;

public class BuildingSelector : MonoBehaviour {

	public Building[] prefabs;
	public BuildingPlacer wheretoPlace;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Place (0);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Place (1);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Place (2);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			Place (3);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			Place (4);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			Place (5);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha7)) {
			Place (6);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha8)) {
			Place (7);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha9)) {
			Place (8);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha0)) {
			Place (9);
		}
	
	}

	void Place (int objectNumber) {
		if (prefabs.Length>objectNumber)
		{
			wheretoPlace.Place((Building)Instantiate(prefabs[objectNumber]));
		}
	}
}
