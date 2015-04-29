using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonCooldown : UnityEngine.UI.Button {
	private string originalText; 
	private bool initiated = false; 
	private long cooldown; 
	// Use this for initialization
	new void Start () {
		if(initiated == false){
			originalText = this.gameObject.GetComponentsInChildren<Text> ()[0].text;
			for(int i = 0; i < GameControl.control.GetButtonTexts().Count; i++){
				if(originalText.Equals(((Node)GameControl.control.GetButtonTexts()[i]).s)){
					this.cooldown = (((Node)GameControl.control.GetButtonTexts()[i]).cooldown);
					((Button) this).interactable = false;
				}
			}
			initiated = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown > System.DateTime.Now.Ticks) {
			((Button)this).GetComponentInChildren<Text> ().text = originalText + " " +((int)((cooldown -System.DateTime.Now.Ticks)/(10000L * 1000L * 60L))).ToString() + "m " 
				+((cooldown -System.DateTime.Now.Ticks)/(10000L * 1000L)- (((int)((cooldown -System.DateTime.Now.Ticks)/(10000L * 1000L * 60L)))*60)).ToString() + "s"; 
		}
		else{
			((Button)this).GetComponentInChildren<Text> ().text = originalText; 
			((Button)this).interactable = true;
		}
	}

	public string GetOriginalText(){
		return originalText; 
	}
	public void SetCooldown(long c){
		cooldown = c;
	}
	public long GetCooldown(){
		return cooldown;
	}
}
