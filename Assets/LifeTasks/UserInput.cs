using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
public class UserInput : MonoBehaviour {
	//public Text text; 
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public void WriteFile(Button b){
		string s;
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
		}
	}
}

