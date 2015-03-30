using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VillagerDialogue : MonoBehaviour {

	public Canvas currentDialogue;
	public Camera camera;

	// Use this for initialization
	void Start () {
		currentDialogue.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		Debug.Log("Click!");
		if (currentDialogue.enabled == false) {
			currentDialogue.enabled = true;
			currentDialogue.worldCamera = camera;
			Button[] buttons = currentDialogue.GetComponentsInChildren<Button>(true);
			for (int i=0;i<buttons.Length;i++) {
				Debug.Log("Button " + (i+1));
				buttons[i].enabled = true;
				buttons[i].interactable = true;
				Debug.Log("Button " + (i+1) + " active: " + buttons[i].IsActive());
				Debug.Log("Button " + (i+1) + " interactable: " + buttons[i].IsInteractable());
			}
			currentDialogue.renderMode = RenderMode.WorldSpace;
		}
		else {
			currentDialogue.enabled = false;
		}
	}
}
