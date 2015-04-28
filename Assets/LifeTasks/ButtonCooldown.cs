using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour {
	private string originalText; 
	// Use this for initialization
	void Start () {
		Debug.Log (this.gameObject.GetComponentsInChildren<Text> () [0].text);
		//originalText = this.gameObject.GetComponentsInChildren<Text> ()[0].text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string GetOriginalText(){
		return originalText; 
	}
}
