using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class TipsJournal : MonoBehaviour {

	public Text textboxTips;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		displayTips ();
	}

	public void displayTips() {
<<<<<<< HEAD
		string tips = "j"; //File.ReadAllText (/*text file containing NPC dialog*/);
				textboxTips.text = tips + "\r\n";
=======

>>>>>>> 456199133589b805919ea73c8efd83948487cec4
		}

}
