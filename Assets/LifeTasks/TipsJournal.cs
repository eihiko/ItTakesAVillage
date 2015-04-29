using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class TipsJournal : MonoBehaviour {

	public Text textboxTips;
	public Text customTip; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		displayTips ();
	}

	public void displayTips() {
		if(GameControl.control.GetTips() != null)
			textboxTips.text =  GameControl.control.GetTips();
		}
	public void writeTips(){
		string s = customTip.text; 
		GameControl.control.SetTips (GameControl.control.GetTips () + s + "\r\n");
		GameControl.control.Save (); 
	}
} 
