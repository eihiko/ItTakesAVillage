using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VillagerDialogue : MonoBehaviour {

	public Canvas currentDialogue;
	public Canvas response;
	public Canvas endDialogue;
	public int idnum;
	public VillagerManager manager;
	public OptionSelection[] options;
	public int prefab;
	public int dialogueNum;
	public WorldNav player;

	// Use this for initialization
	void Start () {
		currentDialogue.enabled = false;
		response.enabled = false;
		endDialogue.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		Debug.Log("Click!");
		player.transform.LookAt (this.transform);
		if (currentDialogue.enabled == false) {
			currentDialogue.enabled = true;
			currentDialogue.worldCamera = FindObjectOfType<Camera>();
			Button[] buttons = currentDialogue.GetComponentsInChildren<Button>(true);
			for (int i=0;i<buttons.Length;i++) {
				//Debug.Log("Button " + (i+1));
				buttons[i].enabled = true;
				buttons[i].interactable = true;
				//Debug.Log("Button " + (i+1) + " active: " + buttons[i].IsActive());
				//Debug.Log("Button " + (i+1) + " interactable: " + buttons[i].IsInteractable());
			}
			options = currentDialogue.GetComponentsInChildren<OptionSelection>(true);
			for (int i=0;i<options.Length;i++) {
				options[i].setVillager(this);
			}
			currentDialogue.renderMode = RenderMode.ScreenSpaceOverlay;
		}
		else {
			currentDialogue.enabled = false;
			if (currentDialogue.Equals(response)) {
				currentDialogue = endDialogue;
			}
		}
	}
	
	public void Response(int button) {
		Debug.Log ("Button " + button + " clicked.");
		currentDialogue.enabled = false;
		currentDialogue = response;
		Text[] options = response.GetComponentsInChildren<Text>(true);
		currentDialogue.enabled = true;
		for(int i=0;i<options.Length;i++) {
			if(i==button) {
				options[i].enabled = true;
			}
			else {
				options[i].enabled = false;
			}
		}
	}
	
	public void Test() {
		Debug.Log ("Option clicked!");
		currentDialogue.enabled = false;
		currentDialogue = response;
		currentDialogue.enabled = true;
	}
}
