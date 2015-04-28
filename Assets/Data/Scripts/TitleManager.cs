using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class TitleManager : MonoBehaviour {

	public InputField text;
	public Button apply;
	public Canvas canvas;
	public Button load;
	
	private InputField character;
	private Button save;

	/**
	 * On load of the title screen, all save files are loaded
	 */
	public void Start() {
		GenerateSaves ();
	}

	/**
	 * Prepares a text area and an accept button to create a new game
	 */
	public void NewGame() {
		if (character == null) {
			character = Instantiate (text) as InputField;
			save = Instantiate (apply) as Button;

			character.transform.SetParent(canvas.transform);
			save.transform.SetParent(canvas.transform);

			character.GetComponent<RectTransform>().localPosition = new Vector2(-50, -200);
			save.GetComponent<RectTransform>().localPosition = new Vector2(100, -200);

			save.onClick.AddListener(() => StartGame());
			save.onClick.AddListener(() => GameControl.control.LoadNextScreen("Overworld"));
		}
	}

	/**
	 * Initializes the save file
	 */
	public void StartGame() {
		GameControl.control.save_name = character.text;
	}

	/**
	 * Procedurally generates all save files
	 */
	public void GenerateSaves() {
		DirectoryInfo dir = new DirectoryInfo (Application.persistentDataPath);
		FileInfo[] files = dir.GetFiles ();
		for (int i = 0; i < 3; i++) {
			Button ld = Instantiate (load) as Button;
			if (files.Length <= i) {
				ld.GetComponentInChildren<Text>().text = "Empty";
			} else {
				string file_name = files[i].Name.Remove(files[i].Name.Length - 4);
				ld.GetComponentInChildren<Text>().text = file_name;
				ld.onClick.AddListener(() => GameControl.control.LoadNextScreen("Overworld"));
			}
			ld.transform.SetParent(canvas.transform);
			RectTransform rt = ld.GetComponent<RectTransform>();
			rt.localPosition = new Vector2(0, i*-50 - 50);
			rt.anchorMax = new Vector2(.53f, .505f);
			rt.anchorMin = new Vector2(.47f, .495f);
			ld.onClick.AddListener(() => SetSave(ld));
		}
	}

	/**
	 * Sets the save name and loads that save
	 */
	public void SetSave(Button b) {
		string name = b.GetComponentInChildren<Text>().text;
		if (name != "Empty") {
			GameControl.control.save_name = name;
			GameControl.control.Load ();
		} else { // Prompt name
			NewGame ();
		}
	}
}
