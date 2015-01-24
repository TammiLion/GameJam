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
		}

	void getSwapInputP1() {
		if (Input.GetButtonDown (SWAP_UP_1_1)) {
			Debug.Log (SWAP_UP_1_1);
			swapCube(getCube(1,1), true);
		}
		if (Input.GetButtonDown (SWAP_DOWN_1_1)) {
			Debug.Log (SWAP_DOWN_1_1);
			swapCube(getCube(1,1), false);
		}
		if (Input.GetButtonDown (SWAP_UP_2_1)) {
			Debug.Log (SWAP_UP_2_1);
			swapCube(getCube(2,1), true);
		}
		if (Input.GetButtonDown (SWAP_DOWN_2_1)) {
			Debug.Log (SWAP_DOWN_2_1);
			swapCube(getCube(2,1), false);
		}
	}

	void getSwapInputP2() {
		if (Input.GetButtonDown (SWAP_UP_1_2)) {
			Debug.Log (SWAP_UP_1_2);
			swapCube(getCube(1,2), true);
		}
		if (Input.GetButtonDown (SWAP_DOWN_1_2)) {
			Debug.Log (SWAP_DOWN_1_2);
			swapCube(getCube(1,2), false);
		}
		Debug.Log (SWAP_UP_2_2 + Input.GetAxisRaw (SWAP_UP_2_2));
		if (Input.GetAxisRaw (SWAP_UP_2_2)>0.0) {
			Debug.Log (SWAP_UP_2_2);
			swapCube(getCube(2,2), true);
		}
		Debug.Log (SWAP_DOWN_2_2 + Input.GetAxisRaw (SWAP_DOWN_2_2));
		if (Input.GetAxisRaw(SWAP_DOWN_2_2)<-0.1) {
			Debug.Log (SWAP_DOWN_2_2);
			swapCube(getCube(2,2), false);
		}
	}

	void swapCube(GameObject cube, bool up) {
		if (up) {
			if (cube == topCube) {
				Debug.Log ("up topCube");
				swapThisCube = null;
				return;
			} else if(cube == belowTopCube) {
				Debug.Log ("up belowTopCube");
				Swap(belowTopCube, topCube);
				swapThisCube = belowTopCube;
				belowTopCube = topCube;
				topCube = swapThisCube;
			} else if (cube == onBottomCube) {
				Debug.Log ("up onBottomCube");
				Swap(onBottomCube, belowTopCube);
				swapThisCube = onBottomCube;
				onBottomCube = belowTopCube;
				belowTopCube = swapThisCube;
			} else if(cube == bottomCube) {
				Debug.Log ("up bottomCube");
				Swap (bottomCube, onBottomCube);
				swapThisCube = bottomCube;
				bottomCube = onBottomCube;
				onBottomCube = swapThisCube;
			}
		} else {
			if(cube == bottomCube) {
				Debug.Log ("down bottomCube");
				swapThisCube = null;
				return;
			} else if(cube == belowTopCube) {
				Debug.Log ("down belowTopCube");
				Swap(belowTopCube, onBottomCube);
				swapThisCube = onBottomCube;
				onBottomCube = belowTopCube;
				belowTopCube = swapThisCube;
			} else if (cube == onBottomCube) {
				Debug.Log ("down onBottomCube");
				Swap(onBottomCube, bottomCube);
				swapThisCube = bottomCube;
				bottomCube = onBottomCube;
				onBottomCube = swapThisCube;
			} else if(cube == topCube) {
				Debug.Log ("down topCube");
				Swap (topCube, belowTopCube);
				swapThisCube = belowTopCube;
				belowTopCube = topCube;
				topCube = swapThisCube;
			}
		}
		swapThisCube = null;
	}


		public void Move (float gravityForce)
		{
				// get movement for X-axis
				float moveHorizontal = Input.GetAxis (HORIZONTAL_1);
				Vector2 movement = new Vector2 (moveHorizontal, gravityForce);
				rigidbody2D.velocity = movement * speed;
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
