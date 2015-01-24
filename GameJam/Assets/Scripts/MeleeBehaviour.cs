using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeleeBehaviour : CubeBehaviour {
	private float attackSpeed = 2;

	// Update is called once per frame
	void Update () {
		bulletTimer += Time.deltaTime;
	}

	public override void Attack() {
		if (HP > 0 && bulletTimer >= 2){
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);
	        if (hit.collider != null && hit.collider.gameObject.tag == "Team") {
	            float distance = Mathf.Abs(hit.point.x - transform.position.x);
	            Debug.Log(hit.collider.gameObject);
	        }
			//bul.origin = transform;
			//bul.Element = Element;
			bulletTimer = 0;
		}
	}
}
