using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingManager : MonoBehaviour{
	public List<Building> buildingPrefabs; 
	public BuildingPlacer buildingPlacer;
	private List<StoredBuilding> buildingList = new List<StoredBuilding>();

	public void addBuilding(Building building) {
		buildingList.Add (new StoredBuilding(building));
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
