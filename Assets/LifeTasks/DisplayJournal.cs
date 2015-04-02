<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DisplayJournal : MonoBehaviour {

	public Text textboxInputs;

	void Update() {
		displayJournal ();
	}

	public void displayJournal() {
		string journal = GameControl.control.GetInput();
		textboxInputs.text = journal;
	}

} 
=======
﻿using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DisplayJournal : MonoBehaviour {

	public Text textboxInputs;

	void Update() {
		displayJournal ();
	}

	public void displayJournal() {
		string journal = GameControl.control.GetInput();
		textboxInputs.text = journal;
	}

} 
>>>>>>> FETCH_HEAD
