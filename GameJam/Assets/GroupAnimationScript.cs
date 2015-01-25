using UnityEngine;
using System.Collections;

public class GroupAnimationScript : MonoBehaviour {

	bool left = true;
	bool up = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 position = transform.position;
		if (left) {
			if (position.x < -16) {
				left = false;
			}
			position.x-=(Time.deltaTime/2);
		} else {
			if (position.x > 16) {
				left = true;
			}
			position.x+=(Time.deltaTime/2);
		}

		if (up) {
			if (position.y < 5.3) {
				up = false;
			}
			position.y -= (Time.deltaTime / 6);
		} else {
			if (position.y > 5.5) {
				up = true;
			}
			position.y += (Time.deltaTime / 6);
		}

		transform.position = position;
	}
}
