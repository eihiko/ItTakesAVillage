using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DisplayJournal : MonoBehaviour {

	public Text textboxInputs;
	public Text customEntry;
	private ArrayList buttons;
	//private ArrayList buttons = new ArrayList(30);
	
	//public StringReader reader;
	void Start(){
		GameControl.control.addToJournal ("");
	}

	void Update() {
		displayJournal ();
		CheckCooldowns (); 
	}

	public void displayJournal() {

			textboxInputs.text = GameControl.control.getJournal();
		}
		
	public void appendJournal(Button b){
		GameControl.control.addToJournal(b.GetComponentInChildren<Text>().text/*GetComponentsInChildren<Text>()[0].text*/);
		b.GetComponentInChildren<Text> ().text += new System.DateTime (System.DateTime.Now.Ticks + 10000L * 1000L * 60L).ToString();
		b.interactable = false;
		AddCooldown (new Node(b, System.DateTime.Now.Ticks + 10000L * 1000L * 60L));
	}

	private void AddCooldown(Node n){
		buttons.Add (n);
		//GameControl.control.GetButtonTexts().Add(n.b.GetComponentInChildren<Text> ().text);
		//buttons.Sort ();
	}

	public void CheckCooldowns(){
		if (buttons == null)
				buttons = new ArrayList (10);
		if(buttons.Count > 0){
			if (((Node)buttons[0]).cooldown <= System.DateTime.Now.Ticks){
				((Node) buttons[0]).b.interactable = true; 
			//	((Node) buttons [0]).b.GetComponentInChildren<Text> ().text = ((Node)buttons[0]).b.GetComponentInChildren<Text> ().text.Substring(0, ((Node)buttons[0]).b.GetComponentInChildren<Text> ().text.Length -20);
				buttons.RemoveAt(0);
			}
		}
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

	private class Node{
		public Node(Button b, long cooldown){
			this.b = b;
			this.cooldown = cooldown;
		}
		public Button b;
		public long cooldown;
	}

} 
