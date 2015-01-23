using UnityEngine;
using System.Collections;

public class TeamScript : MonoBehaviour {

	public string moveButton ="Horizontal_P1";
	public float speed =10;

	private Transform bottomCube; //1
	private Transform topCube; //4
	private Transform onBottomCube; //2
	private Transform belowTopCube; //3

	// Use this for initialization
	void Start () {
		getAllCubes ();
	}
	
	void getAllCubes() {
		bottomCube = transform.Find ("bottom");
		topCube = transform.Find("top");
		onBottomCube = transform.Find ("two");
		belowTopCube = transform.Find("three");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		move ();
	}

	public void move (){
		float moveHorizontal = Input.GetAxis (moveButton);
		Vector2 movement = new Vector2 (moveHorizontal,0);
		rigidbody2D.velocity = movement * speed;
	}
}
