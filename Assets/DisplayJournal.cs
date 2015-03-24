using UnityEngine;
using System.Collections;

public class DisplayJournal : MonoBehaviour {
	
	StringReader reader;

	public void displayJournal() {
				TextAsset journal = (TextAsset)Resources.Load ("input.ext", typeof(TextAsset));
				reader = new StringReader (input.text);
				string txt = reader.ReadLine ();
				Debug.LogType (txt);
		}

}
