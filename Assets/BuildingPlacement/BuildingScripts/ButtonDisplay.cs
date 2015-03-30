using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonDisplay : MonoBehaviour {
	public Button[] buttons;
	public Material good, resourceProblem, locked;
	public BuildingSelector selector;
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i<buttons.Length; i++) {
			if (selector.prefabs[i].locked) {
				buttons[i].image.color = locked.color;
			}
			else if (selector.prefabs[i].HaveResources(selector.wheretoPlace.controller)) {
				buttons[i].image.color = good.color;
			} 
			else {
				buttons[i].image.color = resourceProblem.color;
			}
		}
	}
}
