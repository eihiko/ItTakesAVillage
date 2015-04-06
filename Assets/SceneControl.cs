using UnityEngine;
using System.Collections;

public class SceneControl : MonoBehaviour {

	public 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		if(Input.GetKeyUp (KeyCode.I)){
			Application.LoadLevel ("LifeTasks");
		}
		if(Input.GetKeyUp (KeyCode.P)){
			Application.LoadLevel ("Placement");
		}
		if(Input.GetKeyUp (KeyCode.O)){
			Application.LoadLevel ("Overworld");
		}
	
	}
}
