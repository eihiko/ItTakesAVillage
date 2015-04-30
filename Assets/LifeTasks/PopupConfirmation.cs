using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System;

public class PopupConfirmation : MonoBehaviour {

	public Text window;
	public Button b;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		generateMessage (b);
	}
	
	public void generateMessage(Button b) {
		gameObject.SetActive (true);
	}

	public void closeWindow(Button b) {
		gameObject.SetActive (false);
	} 
}