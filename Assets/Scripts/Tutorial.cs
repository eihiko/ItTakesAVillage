using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public Text startText;
	public Text[] opening;
	public Text[] buildings;
	public Text[] lifetask;
	public Text[] navigation;
	public Text[] npcs;
	public Text[] journal;
	public Text[] saving;
	public Text currentText;
	public Text[] textToDisplay;
	public int textIndex;
	

	// Use this for initialization
	void Start () {
		textIndex = 0;
		currentText = startText;
		//In the future, this will be sized to the part of the tutorial the user wants to cover.
		textToDisplay = new Text[opening.Length+buildings.Length+lifetask.Length+navigation.Length+npcs.Length+
								journal.Length+saving.Length];
		int index = 0;
		opening.CopyTo(textToDisplay,index);
		index += opening.Length;
		buildings.CopyTo(textToDisplay,index);
		index += buildings.Length;
		lifetask.CopyTo(textToDisplay,index);
		index += lifetask.Length;
		navigation.CopyTo(textToDisplay,index);
		index += navigation.Length;
		npcs.CopyTo(textToDisplay, index);
		index += npcs.Length;
		journal.CopyTo(textToDisplay, index);
		index += journal.Length;
		saving.CopyTo(textToDisplay, index);
		}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && textIndex<textToDisplay.Length) {
			currentText.text = textToDisplay[textIndex].text;
			textIndex++;
		}
	}
}
