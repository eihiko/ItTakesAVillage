using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour {
	public Building prefab;
	public BuildingPlacer wheretoPlace;
	public Material good, resourceProblem, locked;

	void Update () {
		if (prefab.IsLocked()) {
			gameObject.GetComponent<Image>().color = locked.color;
		}
		else if (prefab.HaveResources(wheretoPlace.controller)) {
			gameObject.GetComponent<Image>().color = good.color;
		} 
		else {
			gameObject.GetComponent<Image>().color = resourceProblem.color;
		}

	}

	public void Place() {
		wheretoPlace.Place((Building)Instantiate(prefab));
	}
}
