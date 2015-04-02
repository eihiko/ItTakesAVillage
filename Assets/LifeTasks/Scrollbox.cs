using UnityEngine;
using System.Collections;
using System.IO;
public class Scrollbox : MonoBehaviour {
	Vector2 scrollPosition;
	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI(){
		GUILayout.BeginArea (new Rect(460, 220, Screen.width-800, Screen.height-500));
		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (Screen.width-800), GUILayout.Height (Screen.height-550));
		GUI.skin.box.wordWrap = true; 
		try{
		GUILayout.Box(File.ReadAllText ("Inputs\\input.txt"));  
		}
		catch(DirectoryNotFoundException){
			GUILayout.Box("");
		}
		catch(FileNotFoundException){
			GUILayout.Box("");
		}
		GUILayout.EndScrollView ();
		GUILayout.EndArea();

	}
}
