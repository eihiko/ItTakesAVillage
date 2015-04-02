using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
<<<<<<< HEAD
public class UserInput : MonoBehaviour { 
	// Use this for initialization
=======

public class UserInput : MonoBehaviour {

>>>>>>> 456199133589b805919ea73c8efd83948487cec4
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
<<<<<<< HEAD
	
	public void WriteFile(Button b){
=======
	public void writeJournal(Button b){
		string s;
		s = b.GetComponentInChildren<Text>().text;
		GameControl.control.SetInput (GameControl.control.GetInput () + s + "\r\n");
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
>>>>>>> 456199133589b805919ea73c8efd83948487cec4
	}
}

