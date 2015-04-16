using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour{
	public List<Building> buildingPrefabs; 
	public BuildingPlacer buildingPlacer;
	private List<StoredBuilding> buildingList = new List<StoredBuilding>();

	void Start() {
		GameControl.control.Load();
		if (GameControl.control.GetBuildings () == null)
			GameControl.control.SetBuildings (new List<StoredBuilding>());
		loadBuildings(GameControl.control.GetBuildings());
	}

	public void addBuilding(Building building) {
		buildingList.Add (new StoredBuilding(building));
		GameControl.control.SetBuildings (buildingList);
		GameControl.control.Save ();
	}

	public void removeBuilding(Building building) {
		for (int i=0; i<buildingList.Count; i++) {
			StoredBuilding b = buildingList[i];
			if (b.compare(new StoredBuilding(building))) {
				buildingList.Remove (b);
			}
		}
		GameControl.control.SetBuildings (buildingList);
		GameControl.control.Save ();
	}

	//load buildings from the list
	public void loadBuildings(List<StoredBuilding> buildings) {
		foreach (StoredBuilding building in buildings) {
			int buildingType = building.buildingType;
			int x = building.x;
			int y = building.y;
			Building prefab = getBuilding(buildingType);
			//Place the building on the map
			buildingPlacer.Place((Building)Instantiate(prefab), x, y);
		}
	}

	//get a building prefab with the given building type
	private Building getBuilding (int buildingType) {
		foreach (Building building in buildingPrefabs) {
			if (building.buildingType == buildingType) {
				return building;
			}
		}
		Debug.Log ("Could not find a building with building type " + buildingType.ToString());
		return null;
	}
}
