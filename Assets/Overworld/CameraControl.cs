using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Camera Control")]
public class CameraControl : MonoBehaviour {

	public Transform target;
	float distance = 10.0f;
	
	float xSpeed = 250.0f;
	
	private int yMinLimit = -20;
	private int yMaxLimit = 80;
	
	private float x = 0.0f;
	private float y = 0.0f;
				
	void Start () {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>()) {
			GetComponent<Rigidbody> ().freezeRotation = true;
		}
	}
	
	void LateUpdate () {
		if (target) {
			x += Input.GetAxis("Horizontal") * xSpeed * 0.02f;

			y = ClampAngle(y, yMinLimit, yMaxLimit);
			
			Quaternion rotation = Quaternion.Euler(y, x, 0);
			Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
			
			transform.rotation = rotation;
			transform.position = position;
		}
	}
	
	public static float ClampAngle (float angle, float min, float max) {
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}

	/* public float turnSpeed = 4.0f;	// Speed of camera turn.

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

	} */
	
}
