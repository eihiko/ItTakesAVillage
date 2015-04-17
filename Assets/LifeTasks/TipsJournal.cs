using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class TipsJournal : MonoBehaviour {

	public Text textboxTips;
	public Text customTip; 

	// Use this for initialization
	void Start () {
		Debug.Log (System.DateTime.Now);
	}
	
	// Update is called once per frame
	void Update () {
		displayTips ();
	}

	public void displayTips() {
		textboxTips.text =  GameControl.control.GetTips();
		}
	public void writeTips(){
		string s = customTip.text; 
		GameControl.control.SetTips (GameControl.control.GetTips () + s + "\r\n");
		GameControl.control.Save (); 
	}
} 
