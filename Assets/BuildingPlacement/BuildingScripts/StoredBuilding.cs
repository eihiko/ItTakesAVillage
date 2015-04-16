using UnityEngine;
using System.Collections;

[System.Serializable]
public class StoredBuilding {
	public int buildingType;
	public int x;
	public int y;
	
	public StoredBuilding (Building b) {
		this.buildingType = b.buildingType;
		this.x = b.getX ();
		this.y = b.getY ();
	}

	public StoredBuilding (int buildingType, int x, int y) {
		this.buildingType = buildingType;
		this.x = x;
		this.y = y;
	}

	public bool compare(StoredBuilding b2) {
		return (this.buildingType==b2.buildingType && this.x==b2.x && this.y==b2.y);
	}
}