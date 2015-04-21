using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float turnSpeed = 4.0f;	// Speed of camera turn.

	public Transform player;

	public float height = 1f;
	public float distance = 2f;

	private Vector3 offsetX;
	private Vector3 offsetY;

	private bool isRotating;
    private bool isRotatingLeft; // Is the camera being rotated left?
	private bool isRotatingRight; // Is the camera being rotated right?

	void Update()
	{
		if (Input.GetKey ("a")) 
		{
			isRotatingLeft = true;
		}

		if (Input.GetKey ("d")) 
		{
			isRotatingRight = true;
		}

		//Disable movements on button release.
		if (!Input.GetKey ("a")) 
		{
			isRotatingLeft = false;
		}
		if (!Input.GetKey ("d")) 
		{
			isRotatingRight = false;
		}

		// Rotate camera along the X axis
		if(isRotatingLeft) 
		{
			//transform.Rotate (Vector3.down, turnSpeed * Time.deltaTime);
			transform.RotateAround(transform.position, Vector3.down, turnSpeed);
		}
		if(isRotatingRight) 
		{
	//		transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
			transform.RotateAround(transform.position, Vector3.up, turnSpeed);
		}

	}
	
}
