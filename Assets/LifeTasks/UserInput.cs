<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class UserInput : MonoBehaviour {

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void writeJournal(Button b){
		string s;
		s = b.GetComponentInChildren<Text>().text;

		GameControl.control.SetInput (GameControl.control.GetInput () + "\r\n" + s);
		GameControl.control.Save ();

		/*string s;
		if(!Directory.Exists("Inputs"))
			Directory.CreateDirectory("Inputs");
		try{
			s = File.ReadAllText ("Inputs\\input.txt") + " \r\n" + b.GetComponentsInChildren<Text>()[0].text; //((Text)(b.transform.GetChild(0))).text;
		}
		catch(IOException){
			s = b.GetComponentsInChildren<Text>()[0].text; //this.text.text;
		}
		try{
			File.WriteAllText("Inputs\\input.txt", s);
		}
		catch(IOException){
			Debug.Log ("Error"); 
		}*/
	}
}

=======
﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class UserInput : MonoBehaviour {

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void writeJournal(Button b){
		string s;
		s = b.GetComponentInChildren<Text>().text;

		GameControl.control.SetInput (GameControl.control.GetInput () + "\r\n" + s);
		GameControl.control.Save ();

		/*string s;
		if(!Directory.Exists("Inputs"))
			Directory.CreateDirectory("Inputs");
		try{
			s = File.ReadAllText ("Inputs\\input.txt") + " \r\n" + b.GetComponentsInChildren<Text>()[0].text; //((Text)(b.transform.GetChild(0))).text;
		}
		catch(IOException){
			s = b.GetComponentsInChildren<Text>()[0].text; //this.text.text;
		}
		try{
			File.WriteAllText("Inputs\\input.txt", s);
		}
		catch(IOException){
			Debug.Log ("Error"); 
		}*/
	}
}

>>>>>>> FETCH_HEAD
