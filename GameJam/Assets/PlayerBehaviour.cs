using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBehaviour : MonoBehaviour {
	public Transform bulletPrefab;

	private float bulletTimer2 = 0;
	private float bulletTimer3 = 0;
	private float bulletTimer4 = 0;

	private List<Transform> cubes = new List<Transform>();

	// Use this for initialization
	void Start () {
		int i = 0;
		foreach (Transform child in transform)
		{
			cubes.Add(child);
			i++;
		}
	}

	// Update is called once per frame
	void Update () {
		//move left and right
		float xmove = Input.GetAxis("Horizontal_P1");
		rigidbody2D.AddForce(new Vector2(xmove * 80f, 0));

		//fire1
		if (Input.GetButton("Fire1_P1")) {
			cubes[0].GetComponent<CubeBehaviour>().Attack();
		}

		//fire2
		if (Input.GetButton("Fire2_P1")) {
			cubes[1].GetComponent<CubeBehaviour>().Attack();
		}

		//fire3
		if (Input.GetButton("Fire1_P2")) {
			cubes[2].GetComponent<CubeBehaviour>().Attack();
		}

		//fire4
		if (Input.GetButton("Fire2_P2")) {
			cubes[3].GetComponent<CubeBehaviour>().Attack();
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		if (col.gameObject.tag == "Ground"){
			if (Input.GetButton("Jump_P1")) {
				rigidbody2D.AddForce(new Vector2(0, 100f));
			}
		}
	}
}
