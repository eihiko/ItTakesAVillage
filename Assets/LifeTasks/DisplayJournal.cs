using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DisplayJournal : MonoBehaviour {

	public Text textboxInputs;
	
	//public StringReader reader;
	void Start(){
		GameControl.control.addToJournal ("");
	}
	void Update() {
		displayJournal ();
	}

	public void displayJournal() {
				/*TextAsset journal = (TextAsset)Resources.Load ("input.ext", typeof(TextAsset));
				reader = new StringReader (input.text);
				string txt = reader.ReadLine ();
				Debug.LogType (txt);
				*/

		//string journal = File.ReadAllText ("Inputs\\input.txt");
			textboxInputs.text = GameControl.control.getJournal();
		}
	public void appendJournal(Button b){
		GameControl.control.addToJournal(b.GetComponentsInChildren<Text>()[0].text);
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
	}

} 
