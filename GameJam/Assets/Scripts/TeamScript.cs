using UnityEngine;
using System.Collections;

public class TeamScript : MonoBehaviour
{
	//Team
	
	//Controls first player
	public string HORIZONTAL_1 = "Horizontal_P1";
	public string JUMP_1 = "Jump_P1";
	public string FIRE_1_1 = "Fire1_P1";
	public string FIRE_2_1 = "Fire1_P2";
	public string SWAP_UP_1_1 = "Swap_up_1_P1";
	public string SWAP_DOWN_1_1 = "Swap_down_1_P1";
	public string SWAP_UP_2_1 = "Swap_up_2_P1";
	public string SWAP_DOWN_2_1 = "Swap_down_2_P1"; 
	
	//Controls second player
	public string HORIZONTAL_2 = "Horizontal_P2";
	public string JUMP_2 = "Jump_P2";
	public string FIRE_1_2 = "Fire2_P1";
	public string FIRE_2_2 = "Fire2_P2";
	public string SWAP_UP_1_2 = "Swap_up_1_P2";
	public string SWAP_DOWN_1_2 = "Swap_down_1_P2";
	public string SWAP_UP_2_2 = "Swap_up_2_P2";
	public string SWAP_DOWN_2_2 = "Swap_down_2_P2";
	
	private bool axis1InUse = false;
	private bool axis2InUse = false;
	
	public float speed = 10;
	public float gravity = 20;
	public float jumpHeight = 15;
	float moveVertical;
	public bool grounded = false;
	private Transform[] cubesPositions;
	private GameObject bottomCube; //1
	private GameObject topCube; //4
	private GameObject onBottomCube; //2
	private GameObject belowTopCube; //3
	private GameObject swapThisCube;
	Transform myTransform;
	
	// Use this for initialization
	void Start ()
	{
		getAllCubes ();
		myTransform = transform;
	}
	
	void getAllCubes ()
	{
		bottomCube = (GameObject) GameObject.Find ("bottom");
		topCube = (GameObject) GameObject.Find ("top");
		onBottomCube = (GameObject) GameObject.Find ("two");
		belowTopCube = (GameObject) GameObject.Find ("three");
	}
	
	// Update is called once per frame
	
	void Update ()
	{
		getSwapInputP1 ();
		getSwapInputP2 ();
		Move ();
	}
	
	void getSwapInputP1() {
		if (Input.GetButtonDown (SWAP_UP_1_1)) {
			swapCube(getCube(1,1), true);
		}
		if (Input.GetButtonDown (SWAP_DOWN_1_1)) {
			swapCube(getCube(1,1), false);
		}
		/*if (Input.GetAxisRaw (SWAP_UP_2_1) == 0 && axis1InUse) {
			axis1InUse = false;
		}*/
		if (Input.GetButtonDown (SWAP_UP_2_1) &! axis1InUse) {
			axis1InUse = true;
			swapCube(getCube(2,1), true);
		}
		if (Input.GetButtonDown (SWAP_DOWN_2_1) &! axis1InUse) {
			axis1InUse = true;
			swapCube(getCube(2,1), false);
		}
	}
	
	void getSwapInputP2() {
		if (Input.GetButtonDown (SWAP_UP_1_2)) {
			swapCube(getCube(1,2), true);
		}
		if (Input.GetButtonDown (SWAP_DOWN_1_2)) {
			swapCube(getCube(1,2), false);
		}
		if (Input.GetAxisRaw (SWAP_UP_2_2) == 0 && axis2InUse) {
			axis2InUse = false;
		}
		if (Input.GetAxisRaw (SWAP_UP_2_2)>0.0 &! axis2InUse) {
			axis2InUse = true;
			swapCube(getCube(2,2), true);
		}
		if (Input.GetAxisRaw(SWAP_UP_2_2)<-0.1 &! axis2InUse) {
			axis2InUse = true;
			swapCube(getCube(2,2), false);
		}
	}
	
	void swapCube(GameObject cube, bool up) {
		if (up) {
			if (cube == topCube) {
				swapThisCube = null;
				return;
			} else if(cube == belowTopCube) {
				Swap(belowTopCube, topCube);
				swapThisCube = belowTopCube;
				belowTopCube = topCube;
				topCube = swapThisCube;
			} else if (cube == onBottomCube) {
				Swap(onBottomCube, belowTopCube);
				swapThisCube = onBottomCube;
				onBottomCube = belowTopCube;
				belowTopCube = swapThisCube;
			} else if(cube == bottomCube) {
				Swap (bottomCube, onBottomCube);
				swapThisCube = bottomCube;
				bottomCube = onBottomCube;
				onBottomCube = swapThisCube;
			}
		} else {
			if(cube == bottomCube) {
				swapThisCube = null;
				return;
			} else if(cube == belowTopCube) {
				Swap(belowTopCube, onBottomCube);
				swapThisCube = onBottomCube;
				onBottomCube = belowTopCube;
				belowTopCube = swapThisCube;
			} else if (cube == onBottomCube) {
				Swap(onBottomCube, bottomCube);
				swapThisCube = bottomCube;
				bottomCube = onBottomCube;
				onBottomCube = swapThisCube;
			} else if(cube == topCube) {
				Swap (topCube, belowTopCube);
				swapThisCube = belowTopCube;
				belowTopCube = topCube;
				topCube = swapThisCube;
			}
		}
		swapThisCube = null;
	}
	
	
	public void Move ()
	{
		// get movement for X-axis
		float moveHorizontal;
		Debug.Log ("bottomCube playerID: " + bottomCube.GetComponent<CubeScript> ().player);
		if (bottomCube.GetComponent<CubeScript> ().player == 1) {
			moveHorizontal = Input.GetAxis (HORIZONTAL_1);
		} else {
			moveHorizontal = Input.GetAxis (HORIZONTAL_2);
		}
		Vector2 movement = new Vector2 (moveHorizontal, 0);
		rigidbody2D.velocity = movement * speed;
		//rigidbody2D.AddForce (new Vector2(moveHorizontal * 0.5f, 0));
	}
	
	public void Swap (GameObject one, GameObject two)
	{
		Vector3 temp = new Vector3 (one.transform.position.x, one.transform.position.y, one.transform.position.z);
		one.transform.position = two.transform.position;
		two.transform.position = temp;
	}
	
	GameObject getCube (int id, int player)
	{
		CubeScript checkScript = bottomCube.GetComponent<CubeScript> ();
		if (checkScript.player == player && checkScript.id == id) {
			return bottomCube;
		}
		checkScript = topCube.GetComponent<CubeScript> ();
		if (checkScript.player == player && checkScript.id == id) {
			return topCube;
		}
		checkScript = onBottomCube.GetComponent<CubeScript> ();
		if (checkScript.player == player && checkScript.id == id) {
			return onBottomCube;
		}
		checkScript = belowTopCube.GetComponent<CubeScript> ();
		if (checkScript.player == player && checkScript.id == id) {
			return belowTopCube;
		}
		return null;
	}
}