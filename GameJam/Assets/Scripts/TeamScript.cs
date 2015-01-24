using UnityEngine;
using System.Collections;

public class TeamScript : MonoBehaviour
{

		public string moveButton = "Horizontal_P1";
		public string jumpButton = "Jump_P1";
		public string fire1Button = "Fire1_P1";
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
		if (Input.GetButtonDown (fire1Button)) {
			Debug.Log ("figure out how the f we h");
			Swap (bottomCube, onBottomCube);
			}
		}

		void FixedUpdate ()
		{
				//Check if cube is grounded
				if (bottomCube.position.y <= -0.2) {
						grounded = true;
						// reset gravity acceleration since it is grounded
						moveVertical = 0;
						// jump
						if (Input.GetButtonDown (jumpButton)) {
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
				float moveHorizontal = Input.GetAxis (moveButton);
				Vector2 movement = new Vector2 (moveHorizontal, gravityForce);
				rigidbody2D.velocity = movement * speed;
		}

		public void Swap (Transform one, Transform two)
		{
				Vector3 temp =  new Vector3(one.transform.position.x, one.transform.position.y, one.transform.position.z);
				one.transform.position = two.transform.position;
				two.transform.position = temp;
		}
}
