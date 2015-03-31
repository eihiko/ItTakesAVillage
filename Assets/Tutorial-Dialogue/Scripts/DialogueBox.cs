using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour {

	public Image panel;
	public Button option1, option2, option3, option4;
	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void setEnabled() {
		panel.enabled = true;
		option1.enabled = true;
		option2.enabled = true;
		option3.enabled = true;
		option4.enabled = true;
		text.enabled = true;
	}
}
