using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankBehaviour : CubeBehaviour {
	private float dmg = 1f;

	// Update is called once per frame
	void Update () {

	}

	public override void TakeDamage (CubeBehaviour origin, float dmg) {
		HP -= dmg * getElementWeakness(origin.Element) / getWeaponResist(origin.Weapon);

		//get stunned
		origin.GetStunned();

		if (HP <= 0) {
			renderer.material.color = Color.black;
		}
	}
}
