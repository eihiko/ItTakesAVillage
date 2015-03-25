using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DisplayJournal : MonoBehaviour {

	public Text textbox;
	
	//public StringReader reader;

	void Update() {
		displayJournal ();
	}

	public void displayJournal() {
				/*TextAsset journal = (TextAsset)Resources.Load ("input.ext", typeof(TextAsset));
				reader = new StringReader (input.text);
				string txt = reader.ReadLine ();
				Debug.LogType (txt);
				*/

		string journal = File.ReadAllText ("Inputs\\input.txt");
		textbox.text = journal + "\n";
		}

} 
