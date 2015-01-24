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
		private Transform bottomCube; //1
		private Transform topCube; //4
		private Transform onBottomCube; //2
		private Transform belowTopCube; //3
		Transform myTransform;

		// Use this for initialization
		void Start ()
		{
				getAllCubes ();
				myTransform = transform;
		}
	
		void getAllCubes ()
		{
				bottomCube = transform.Find ("bottom");
				topCube = transform.Find ("top");
				onBottomCube = transform.Find ("two");
				belowTopCube = transform.Find ("three");
		}
	
		// Update is called once per frame

		void Update ()
		{
				if (Input.GetButtonDown (FIRE_1_1)) {
						Debug.Log ("figure out how the f we h");
						Swap (bottomCube, onBottomCube);
				}
		getSwapInput ();
		}

		void getSwapInput() {
	}

		void FixedUpdate ()
		{
				//Check if cube is grounded
				if (bottomCube.position.y <= -0.2) {
						grounded = true;
						// reset gravity acceleration since it is grounded
						moveVertical = 0;
						// jump
						if (Input.GetButtonDown (JUMP_1)) {
								moveVertical = jumpHeight;
								grounded = false;
						}
				}
				// add force of gravity
				moveVertical -= gravity * Time.fixedDeltaTime;
				Move (moveVertical);
		}

		public void Move (float gravityForce)
		{
				// get movement for X-axis
				float moveHorizontal = Input.GetAxis (HORIZONTAL_1);
				Vector2 movement = new Vector2 (moveHorizontal, gravityForce);
				rigidbody2D.velocity = movement * speed;
		}

		public void Swap (Transform one, Transform two)
		{
				Vector3 temp = new Vector3 (one.transform.position.x, one.transform.position.y, one.transform.position.z);
				one.transform.position = two.transform.position;
				two.transform.position = temp;
		}

		Transform getCube (int player, int id)
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
