using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DisplayJournal : MonoBehaviour {

	public Text textboxInputs;
	public Text customEntry;
	private ArrayList buttons;

	void Start(){
		GameControl.control.addToJournal ("");
		if (GameControl.control.GetButtonTexts () == null)
				GameControl.control.SetButtonTexts (new ArrayList (10));
		for (int i=0; i < GameControl.control.GetButtonTexts().Count; i++) {
			if(((Node)GameControl.control.GetButtonTexts()[i]).cooldown < System.DateTime.Now.Ticks)
				GameControl.control.GetButtonTexts().RemoveAt(i);
		}
	}

	void Update() {
		displayJournal ();
	}

	public void displayJournal() {
			
			textboxInputs.text = GameControl.control.getJournal();
		}
		
	public void appendJournal(ButtonCooldown b){
		GameControl.control.addToJournal(b.GetComponentInChildren<Text>().text/*GetComponentsInChildren<Text>()[0].text*/);
		b.SetCooldown (System.DateTime.Now.Ticks + 10000L * 1000L * 60L);
		((Button)b).interactable = false;
		AddCooldown (new Node (b.GetComponentInChildren<Text> ().text, b.GetCooldown ()));
	}

	private void AddCooldown(Node n){
		GameControl.control.GetButtonTexts ().Add (n);
		Debug.Log (((Node)GameControl.control.GetButtonTexts ()[0]).s);
	}


	public void addResources(int x){
		if (x == 1)
			GameControl.control.AddCoin (100);
		else if (x == 2)
			GameControl.control.AddEnergy (10);
		else if (x == 3)
			GameControl.control.AddFood (100);
		else if (x == 4)
			GameControl.control.AddLumber (100);
		else if (x == 5)
			GameControl.control.AddMorale (10);
		else if (x == 6)
			GameControl.control.AddSilk (100);
		else
			GameControl.control.AddStone (100);
		GameControl.control.Save ();
	}

	public void CustomEntry(){
		GameControl.control.SetInput (GameControl.control.GetInput () + customEntry.text + "\r\n");
		GameControl.control.Save ();
	}


} 
