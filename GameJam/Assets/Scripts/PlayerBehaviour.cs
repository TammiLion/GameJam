using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float xmove = Input.GetAxis("Horizontal_P1");

		rigidbody2D.AddForce(new Vector2(xmove * 10f, 0));
	}

	void OnCollisionStay2D(Collision2D col) {
		if (col.gameObject.tag == "Ground"){
			if (Input.GetButton("Jump_P1")) {
				rigidbody2D.AddForce(new Vector2(0, 100f));
			}
		}
	}
}
