using UnityEngine;
using System.Collections;

public class ObjectInfoObject : MonoBehaviour {
	public UnityEngine.UI.Text ObjectName;
	
	// Use this for initialization
	void Start () {
		renderer.enabled = false;
		ObjectName.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
