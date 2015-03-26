using UnityEngine;
using System.Collections;

public class BuildingSelect : MonoBehaviour {

	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}

	void OnMouseEnter() {
		rend.material.color = Color.gray;
	}
	
	void OnMouseExit() {
		rend.material.color = Color.blue;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
