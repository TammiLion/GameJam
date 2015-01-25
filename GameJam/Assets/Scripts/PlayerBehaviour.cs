using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {
	private List<Transform> cubes = new List<Transform>();
	private List<int> cubeOrder = new List<int>();

	public float HP = 100f;
	public Transform hpbar;

	public GameObject winText;
	private float resetTimer = 0f;

	private bool axis1InUse = false;
	private bool axis2InUse = false;

	private GameObject bottomCube; //1
	private GameObject topCube; //4
	private GameObject onBottomCube; //2
	private GameObject belowTopCube; //3
	private GameObject swapThisCube;

	public string TEAM_TAG = "";

	public string HORIZONTAL_1 = "Horizontal_P1";
	public string HORIZONTAL_2 = "Horizontal_P2";

	public string SWAP_UP_1_1 = "Swap_up_1_P1";
	public string SWAP_DOWN_1_1 = "Swap_down_1_P1";
	public string SWAP_UP_2_1 = "Swap_up_2_P1";
	public string SWAP_DOWN_2_1 = "Swap_down_2_P1";
	public string SWAP_UP_1_2 = "Swap_up_1_P2";
	public string SWAP_DOWN_1_2 = "Swap_down_1_P2";
	public string SWAP_UP_2_2 = "Swap_up_2_P2";
	public string SWAP_DOWN_2_2 = "Swap_down_2_P2";

	public string JUMP_P1 = "Jump_P1";
	public string JUMP_P2 = "Jump_P2";
	public string FIRE1_P1 = "";
	public string FIRE2_P1 = "";
	public string FIRE1_P2 = "";
	public string FIRE2_P2 = "";



	// Use this for initialization
	void Start () {
		getAllCubes();
		int i = 0;
		foreach (Transform child in transform)
		{
			cubes.Add(child);
			cubeOrder.Add(i);
			i++;
		}
		printCubes();

		winText.GetComponent<Text> ().enabled = false;
	}

	void getAllCubes ()
	{
		bottomCube = (GameObject) GameObject.Find ("bottom"+TEAM_TAG);
		topCube = (GameObject) GameObject.Find ("top"+TEAM_TAG);
		onBottomCube = (GameObject) GameObject.Find ("two"+TEAM_TAG);
		belowTopCube = (GameObject) GameObject.Find ("three"+TEAM_TAG);
	}

	// Update is called once per frame
	void Update () {
		//move left and right
		/*float xmove;
		if (bottomCube.GetComponent<CubeScript> ().player == 1) {
			xmove = Input.GetAxis (HORIZONTAL_1);
		} else {
			xmove = Input.GetAxis (HORIZONTAL_2);
		}*/
		//rigidbody2D.AddForce(new Vector2(xmove * 10f, 0));

		//fire1
		if (Input.GetButton(FIRE1_P1)) {
			cubes[0].GetComponent<CubeBehaviour>().Attack();
		}

		//fire2
		if (Input.GetButton(FIRE2_P1)) {
			cubes[1].GetComponent<CubeBehaviour>().Attack();
		}

		//fire3
		if (Input.GetButton(FIRE1_P2)) {
			cubes[2].GetComponent<CubeBehaviour>().Attack();
		}

		//fire4
		if (Input.GetButton(FIRE2_P2)) {
			cubes[3].GetComponent<CubeBehaviour>().Attack();
		}

		getSwapInputP1();
		getSwapInputP2();

		if (resetTimer >= 5f) {
			Application.LoadLevel ("MainMenu");
		}

		hpbar.GetComponent<HPBehaviour> ().SetHP (HP);
		if (HP <= 0) {
			if (TEAM_TAG == "one") {
				winText.GetComponent<Text> ().text = "Winner Team TWO -->";
			} else {
				winText.GetComponent<Text> ().text = "<-- Winner Team ONE";
			}
			winText.GetComponent<Text> ().enabled = true;

			resetTimer += Time.deltaTime;
		}
	}

	void getSwapInputP1() {
		if (Input.GetButtonDown (SWAP_UP_1_1)) {
			swapCube(getCube(1,1), true);
		}
		if (Input.GetButtonDown (SWAP_DOWN_1_1)) {
			//swapCube(getCube(1,1), false);
		}
		if (Input.GetButtonDown(SWAP_UP_2_1)) {
			swapCube(getCube(2,1), true);
		}
		if (Input.GetButtonDown(SWAP_DOWN_2_1)) {
			//swapCube(getCube(2,1), false);
		}
	}

	void getSwapInputP2() {
		if (Input.GetButtonDown (SWAP_UP_1_2)) {
			swapCube(getCube(1,2), true);
		}
		if (Input.GetButtonDown (SWAP_DOWN_1_2)) {
			//swapCube(getCube(1,2), false);
		}
		if (Input.GetButtonDown(SWAP_UP_2_2)) {
			swapCube(getCube(2,2), true);
		}
		if (Input.GetButtonDown(SWAP_DOWN_2_2)) {
			//swapCube(getCube(2,2), false);
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


	void printCubes() {
		string cubes =  "";
		foreach (int i in cubeOrder) {
			cubes+="," + i;
		}
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

	/*void OnCollisionStay2D(Collision2D col) {
		if (col.gameObject.tag == "Ground"){
			if (bottomCube.GetComponent<CubeScript> ().player == 1) {
				if (Input.GetButton(JUMP_P1)) {
					rigidbody2D.AddForce(new Vector2(0, 100f));
				}
			} else {
				if (Input.GetButton(JUMP_P2)) {
					rigidbody2D.AddForce(new Vector2(0, 100f));
				}
			}
		}
	}*/
}
