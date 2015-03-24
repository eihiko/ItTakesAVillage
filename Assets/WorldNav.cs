using UnityEngine;
using System.Collections;

public class WorldNav : MonoBehaviour {
 
	public GameObject building;

	Ray ray1;
	//Checks whether the button has been clicked.
	private bool flag1 = false;
	//Destination point
	private Vector3 endPoint;
	//Speed of the player; can be modified!
	public float speed = 10f;
	//Vertical position of the gameobject
	private float yAxis;

	private Vector3 desiredVelocity;
	
	private float lastSqrMag;
	
	void Start(){
		//save the y axis
		yAxis = gameObject.transform.position.y;



		//reset lastSqrMag
		lastSqrMag = Mathf.Infinity;



	}

	// Update is called once per frame
	void Update() {

		//if (Input.GetMouseButtonDown (0)) {

		//	ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);

		//	if(Physics.Raycast(ray1,out building.collider)) {
		//		building.collider.renderer.material.color = Color.red;
		//	}
		//}

		//check if the screen is right-clicked   
		if(Input.GetMouseButton(1))
		{

			//declare a variable of RaycastHit struct
			RaycastHit hit;
			//Create a Ray on the clicked position
			Ray ray;
			
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			//Check if the ray hits any collider
			if(Physics.Raycast(ray,out hit)) {


				//set a flag to indicate to move the gameobject
				flag1 = true;
				//save the clicked position
				endPoint = hit.point;
				//as we do not want to change the y axis value based on click position, reset it to original y axis value
				endPoint.y = yAxis;
				Debug.Log(endPoint);
				
			}
			
		}

		//check if the flag for movement is true and the current gameobject position is not same as the clicked position
		if(flag1 && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)){
			//Look at the endpoint.
			gameObject.transform.LookAt(endPoint);

			//calculate directional vector to target
			Vector3 directionalVector = (endPoint - gameObject.transform.position).normalized * speed;
			
			//apply to rigidbody velocity
			desiredVelocity = directionalVector;

			// Move the Screen
			// Zoom in and out (scrolling wheel up and down)

			Pathfinding();

			flag1 = false;
						
		}
		//set the movement indicator flag to false if the endPoint and current gameobject position are equal
		else if(flag1 && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) {
			flag1 = false;
			Debug.Log("I am here");
		}

	}

	// Update is called once per frame
	void FixedUpdate () {

		if(Mathf.Approximately(gameObject.transform.position.x, endPoint.x) && Mathf.Approximately(transform.position.z, endPoint.z)) {
			//the player stops at the destination.
			desiredVelocity = Vector3.zero;
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}


		rigidbody.velocity = desiredVelocity;

	}

	void Pathfinding() {

	}
}