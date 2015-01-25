using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour {
	public float HP = 25f;
	public string Element;
	public string Weapon = "Ranged";

	public int pos;

	public Transform bulletPrefab;

	public float bulletTimer = 0;

	public bool stunned = false;
	private float stunTimer = 0f;

	// Use this for initialization
	public void Start () {
		setColor();
	}

	void setColor () {
		switch(Element) {
			case "Fire":
				renderer.material.color = Color.red;
				break;
			case "Earth":
				renderer.material.color = Color.green;
				break;
			case "Electro":
				renderer.material.color = Color.yellow;
				break;
			case "Water":
				renderer.material.color = Color.blue;
				break;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (stunTimer <= 0f) {
			stunned = false;
			setColor();
		} else {
			stunTimer -= Time.deltaTime;
		}
	}

	public void GetStunned () {
		renderer.material.color = Color.magenta;

		stunned = true;
		stunTimer = 3f;
	}

	public virtual void Attack() {
		Debug.Log("Bongiorno");
	}

	public virtual void TakeDamage (CubeBehaviour origin, float dmg) {
		HP -= dmg * getElementWeakness(origin.Element) / getWeaponResist(origin.Weapon);
		Debug.Log("Cube HP: " + HP);
		if (HP <= 0) {
			renderer.material.color = Color.black;
		}
	}

	public virtual void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "ProjectileTeam1") {
			BulletBehaviour vs = col.gameObject.GetComponent<BulletBehaviour>();

			TakeDamage(vs.origin.GetComponent<CubeBehaviour>(), vs.dmg);
			Destroy(col.gameObject);
		}
	}

	public float getElementWeakness(string vsElement) {
		if ((Element == "Fire" && vsElement == "Water") ||
			(Element == "Earth" && vsElement == "Fire") ||
			(Element == "Electro" && vsElement == "Earth") ||
			(Element == "Water" && vsElement == "Electro")) {
			return 2;
		} else {
			return 1;
		}
	}

	public float getWeaponResist(string vsWeapon) {
		if ((Weapon == "Melee" && vsWeapon == "Tank") ||
			(Weapon == "Tank" && vsWeapon == "Ranged") ||
			(Weapon == "Ranged" && vsWeapon == "Melee")) {
			return 2;
		} else {
			return 1;
		}
	}
}
