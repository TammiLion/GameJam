using UnityEngine;
using System.Collections;

public class TeamScript : MonoBehaviour {

	public string moveButton ="Horizontal_P1";
	public string jumpButton ="Jump_P1";
	public float speed =10;
	public float gravity = 20;
	public float jumpHeight = 1500;
	float moveVertical;
	bool grounded = false;

	private Transform bottomCube; //1
	private Transform topCube; //4
	private Transform onBottomCube; //2
	private Transform belowTopCube; //3
	Transform myTransform;

	// Use this for initialization
	void Start () {
		getAllCubes ();
		myTransform = transform;
	}
	
	void getAllCubes() {
		bottomCube = transform.Find ("bottom");
		topCube = transform.Find("top");
		onBottomCube = transform.Find ("two");
		belowTopCube = transform.Find("three");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (myTransform.position.y < -0.5) {
			grounded = true;
		}
		if (Input.GetButtonDown(jumpButton) && grounded == true) {
			rigidbody2D.AddForce (Vector2.up * jumpHeight);
			grounded = false;
		}

		moveVertical -= gravity * Time.fixedDeltaTime;
		move (moveVertical);
	}

	public void move (float vertical){
		float moveHorizontal = Input.GetAxis (moveButton);



		Vector2 movement = new Vector2 (moveHorizontal,vertical);
		rigidbody2D.velocity = movement * speed;
	}
}
