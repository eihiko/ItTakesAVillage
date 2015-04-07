using UnityEngine;
using System.Collections;

public class LockToTarget : MonoBehaviour {

	public Transform target;
	public float offset_x;
	public float offset_y;
	public float offset_z;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = new Vector3(
			target.position.x - offset_x, 
			target.position.y - offset_y, 
			target.position.z - offset_z
		);
		transform.position = v;
	}
}
