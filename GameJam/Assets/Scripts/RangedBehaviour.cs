using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangedBehaviour : CubeBehaviour {

	// Update is called once per frame
	void Update () {
		bulletTimer += Time.deltaTime;
	}

	public override void Attack() {
		if (HP > 0 && bulletTimer >= 0.5f && !stunned){
			int dir = 0;
			if (transform.parent.gameObject.GetComponent<PlayerBehaviour> ().TEAM_TAG == "one") {
				dir = 1;
			} else {
				dir = -1;
			}
			Transform bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + dir * 1f, transform.position.y, 0f), Quaternion.identity) as Transform;
			BulletBehaviour bul = bullet.GetComponent<BulletBehaviour>();
			bul.dir = dir;

			bul.origin = transform;
			bul.Element = Element;
			bulletTimer = 0;
		}
	}
}
