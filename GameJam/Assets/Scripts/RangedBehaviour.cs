using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangedBehaviour : CubeBehaviour {
	
	// Update is called once per frame
	void Update () {
		bulletTimer += Time.deltaTime;
	}

	public override void Attack() {
		if (HP > 0 && bulletTimer >= 3){
			Transform bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + 1f, transform.position.y, 0f), Quaternion.identity) as Transform;
			BulletBehaviour bul = bullet.GetComponent<BulletBehaviour>();
			bul.origin = transform;
			bul.Element = Element;
			bulletTimer = 0;
		}
	}
}
