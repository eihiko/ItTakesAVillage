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
		if(currentDialogue){
			currentDialogue.enabled = false;
		}
		if(response){
			response.enabled = false;
		}
		if(endDialogue){
			endDialogue.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		player.Stall ();
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
		currentDialogue.enabled = false;
		currentDialogue = response;
		currentDialogue.enabled = true;
	}
}
