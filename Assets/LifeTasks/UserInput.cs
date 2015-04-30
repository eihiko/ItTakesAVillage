using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System;

public class UserInput : MonoBehaviour {
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	

	/*public void writeJournal(Button b){
		string s;
		s = b.GetComponentInChildren<Text>().text;
		GameControl.control.SetInput (GameControl.control.GetInput () + s + "\r\n");
		GameControl.control.Save ();

	}*/

	
	public void getTodaysDate(Button b) {
		DateTime thisDate = DateTime.Today;
		string s = b.GetComponentInChildren<Text> ().text;
		s = thisDate.ToString ("D");
		GameControl.control.SetInput (GameControl.control.GetInput () + s + "\r\n");
		GameControl.control.Save ();
		
	}
}

