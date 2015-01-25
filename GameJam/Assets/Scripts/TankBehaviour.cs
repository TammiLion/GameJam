using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankBehaviour : CubeBehaviour {
	private float dmg = 1f;
	public Transform defence;

	// Update is called once per frame
	void Update () {

	}

	public override void TakeDamage (CubeBehaviour origin, float dmg) {
		transform.parent.GetComponent<PlayerBehaviour>().HP -= dmg * getElementWeakness(origin.Element) / getWeaponResist(origin.Weapon);

		//get stunned
		origin.GetStunned();

		//Instantiate (defence, transform.posotion, transform.rotation); //defense
	}
}
