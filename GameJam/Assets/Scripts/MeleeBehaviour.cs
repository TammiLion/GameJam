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
			Transform bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + 1f, transform.position.y, 0f), Quaternion.identity) as Transform;
			BulletBehaviour bul = bullet.GetComponent<BulletBehaviour>();
			bul.origin = transform;
			bul.Element = Element;
			bulletTimer = 0;
		}
	}
}
