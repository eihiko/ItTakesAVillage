using UnityEngine;
using System.Collections;

public class WorldNav : MonoBehaviour {
 
	public Material building1;
	public Material building2;

	public GameObject controller;

	private float XPos;
	private float YPos;
	private float ZPos;

	Ray selectRay;
	RaycastHit selectHit;
	//Checks whether the button has been clicked.
	private bool flag = false;
	//Destination point
	private Vector3 endPoint;
	//Speed of the player; can be modified!
	public float speed = 10;
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

		XPos = gameObject.transform.position.x;
		YPos = gameObject.transform.position.y;
		ZPos = gameObject.transform.position.z;
		
		//Checks for if the an object clicked by the left mouse button is the building.
		if (Input.GetMouseButtonDown (0)) {
			Select();
		}

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
				flag = true;
				//save the clicked position
				endPoint = hit.point;
				//as we do not want to change the y axis value based on click position, reset it to original y axis value
				endPoint.y = yAxis;
				Debug.Log("end point: "+endPoint);
				
			}
			
		}



		//check if the flag for movement is true and the current gameobject position is not same as the clicked position
		if(flag){
			//Look at the endpoint.
			gameObject.transform.LookAt(endPoint);

			//calculate directional vector to target
			Vector3 directionalVector = (endPoint - gameObject.transform.position).normalized * speed;
			
			//apply to rigidbody velocity
			desiredVelocity = directionalVector;

			// Move the Screen
			// Zoom in and out (scrolling wheel up and down)

			Pathfinding();

			float difference = (gameObject.transform.position.magnitude)/(endPoint.magnitude);
			Debug.Log("curser position: "+endPoint.magnitude+"\n object position: "+gameObject.transform.position.magnitude);
			Debug.Log("difference: "+difference);
			if(difference >= 0.98 && difference <= 1.02)
				flag = false;

			if(Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) {
				flag = false;						
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (!flag) {
			desiredVelocity = Vector3.zero;
		}
		
		rigidbody.velocity = desiredVelocity;
		
		this.GetComponentInChildren<Animator>().SetFloat("Speed",this.rigidbody.velocity.magnitude);
		Debug.Log (this.rigidbody.velocity.magnitude);

	}
	
	void Pathfinding() {

	}

	void Select() {
		selectRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if(Physics.Raycast(selectRay, out selectHit)) {
			if(selectHit.collider.tag == "Building") {
				//Changes the building into one of two different colors.
				if(selectHit.collider.renderer.material.color == building1.color) {
					selectHit.collider.renderer.material.SetColor ("_Color", building2.color);
				}
				else {
					selectHit.collider.renderer.material.SetColor ("_Color", building1.color);
				}			
			}
		}

	}
}