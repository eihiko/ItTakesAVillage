using UnityEngine;
using System.Collections;

public class ViewControl : MonoBehaviour {

	public 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PlacementView(){
		Application.LoadLevel ("Placement");
	}
	
	public void OverworldView(){
		Application.LoadLevel ("Overworld");
	} 
	
	public void InputView(){
		Application.LoadLevel ("LifeTasks");
	}
	
	public void ResetView(){
		GameControl.control.Reset ();
		Application.LoadLevel ("Overworld");
	}
	
	public void WinView(){
		Application.LoadLevel ("WinScreen");
	}

	public void ExitView() {
		Application.LoadLevel ("TitleScene");
	}
}
