using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeleeBehaviour : CubeBehaviour {
	private float attackSpeed = 0.1f;
	private float dmg = 5f;

	private RaycastHit2D hit;

	public Transform glove;
	private float gloveTimer = 0f;

	public LayerMask mask;

	// Update is called once per frame
	void Update () {
		bulletTimer += Time.deltaTime;

		if (gloveTimer <= 0) {
			glove.renderer.enabled = false;
		} else {
			gloveTimer -= Time.deltaTime;
		}
	}

	void FixedUpdate () {
		hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.6f, transform.position.y), Vector2.right, 2f, mask);
		Debug.DrawRay(transform.position, Vector2.right * 2f, Color.red);
	}

	public override void Attack() {
		if (HP > 0 && bulletTimer >= attackSpeed){
			glove.renderer.enabled = true;
			gloveTimer = 0.05f;

			if (hit.collider != null && hit.collider.gameObject.tag == "Cube") {
				CubeBehaviour vs = hit.collider.gameObject.GetComponent<CubeBehaviour>();
				vs.TakeDamage(Element, Weapon, dmg);
	        }

			bulletTimer = 0f;
		}
	}
}
